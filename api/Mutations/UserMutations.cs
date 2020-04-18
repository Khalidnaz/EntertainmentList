using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using api.Models;
using api.Repositories;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Types;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EntertainmentList.Mutations
{
  [ExtendObjectType(Name = "Mutation")]
  public class UserMutations
  {
    private readonly IConfiguration _config;
    private readonly IAuthRepository _repo;

    public UserMutations(IAuthRepository repo, IConfiguration config)
    {
      _repo = repo ?? throw new ArgumentNullException(nameof(repo));
      _config = config;
    }

    /// <summary>
    /// Creates a new user.
    /// </summary>
    public async Task<User> AddNewUser(UserInput user)
    {
      if (await _repo.DoesUserExist(user.Email))
      {
        throw new QueryException(
          ErrorBuilder
            .New()
            .SetMessage("Email is already being used")
            .SetCode("400")
            .Build()
        );
      }

      if (string.IsNullOrEmpty(user.Password))
      {
        throw new QueryException(
          ErrorBuilder
            .New()
            .SetMessage("The password cannot be empty.")
            .SetCode("PASSWORD_EMPTY")
            .Build()
        );
      }

      return await _repo.Register(user);
    }

    /// <summary>
    /// authenticate user
    /// </summary>
    public async Task<AuthUser> Login(LoginUserInput input)
    {
      var user = await _repo.AuthenticateUser(input);
      var key = new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(
          _config.GetSection("AppSettings:Token").Value
        )
      );

      var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Expires = DateTime.Now.AddDays(1),
        SigningCredentials = credentials
      };

      var tokenHandler = new JwtSecurityTokenHandler();
      var token = tokenHandler.CreateToken(tokenDescriptor);
      var authedUser = new AuthUser()
      {
        FirstName = user.FirstName,
        LastName = user.LastName,
        Email = user.Email,
        Token = tokenHandler.WriteToken(token)
      };

      return authedUser;
    }
  }
}