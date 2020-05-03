using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using api.Models.Users;
using api.Repositories;
using HotChocolate;
using HotChocolate.Execution;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace api.Graphql
{
  public class Mutation
  {
    private readonly IConfiguration _config;

    private readonly IAuthRepository _repo;

    public Mutation(IAuthRepository repo, IConfiguration config)
    {
      _config = config;
      _repo = repo;
    }

    /// <summary>
    /// create new user
    /// </summary>

    public async Task<User> CreateUser(UserInput user)
    {
      if (await _repo.DoesUserExist(user.Email))
      {
        throw new QueryException(
          ErrorBuilder.New()
            .SetMessage("Email is already being used.")
            .SetCode("EMAIL_EXIST")
            .Build());
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

      var claims = new[]
      {
				// id
				new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Name, user.Email.ToString()),
        new Claim(ClaimTypes.Role, "user")
      };

      var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(claims),
        Expires = DateTime.Now.AddDays(1),
        SigningCredentials = credentials
      };

      var tokenHandler = new JwtSecurityTokenHandler();
      var token = tokenHandler.CreateToken(tokenDescriptor);
      var authedUser = new AuthUser
      {
        Id = user.Id,
        FirstName = user.FirstName,
        LastName = user.LastName,
        Email = user.Email,
        Token = tokenHandler.WriteToken(token)
      };

      return authedUser;
    }

    /// <summary>
    /// add movie to watch list
    /// </summary>
  }
}