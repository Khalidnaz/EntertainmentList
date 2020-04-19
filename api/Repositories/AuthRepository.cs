using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using api.Models.Users;
using HotChocolate;
using HotChocolate.Execution;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
  public class AuthRepository : IAuthRepository
  {
    /// <summary>
    /// Size of salt
    /// </summary>
    private const int SaltSize = 16;

    /// <summary>
    /// Size of hash
    /// </summary>
    private const int HashSize = 20;

    private readonly ApplicationDbContext _context;

    public AuthRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<bool> DoesUserExist(string email)
    {
      if (await _context.users.AnyAsync(x => x.Email == email))
      {
        return true;
      }
      return false;
    }

    public async Task<User> Register(UserInput input)
    {
      String hashedPassword = String.Empty;

      var newUser = new User()
      {
        FirstName = input.FirstName,
        LastName = input.LastName,
        Email = input.Email,
        Password = HashPassword(input.Password),
      };

      await _context.users.AddAsync(newUser);
      await _context.SaveChangesAsync();
      return newUser;
    }

    public async Task<User> AuthenticateUser(LoginUserInput input)
    {
      var user = await _context.users.FirstOrDefaultAsync(x => x.Email == input.Email);

      if (user == null)
      {
        throw new QueryException(
        ErrorBuilder
          .New()
          .SetMessage("User does not exist")
          .SetCode("NO_USER")
          .Build()
        );
      }

      if (!ValidatePassword(input.Password, user.Password))
      {
        throw new QueryException(
          ErrorBuilder
            .New()
            .SetMessage("Passwords do not match.")
            .SetCode("WRONG_PASSWORD")
            .Build()
        );
      }

      return user;
    }

    private string HashPassword(string password)
    {
      //create salt
      byte[] salt;
      new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltSize]);

      //create hash for password
      var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 1000);
      var hash = pbkdf2.GetBytes(HashSize);

      //combine salt and hash together into hashbytes
      var hashBytes = new byte[36];
      Array.Copy(salt, 0, hashBytes, 0, 16);
      Array.Copy(hash, 0, hashBytes, 16, 20);

      //create hashed password
      string hashedPassword = Convert.ToBase64String(hashBytes);
      return hashedPassword;
    }

    public bool ValidatePassword(string enteredPassword, string savedHashedPassword)
    {
      var hashBytes = Convert.FromBase64String(savedHashedPassword);

      /* Get the salt */
      var salt = new byte[16];
      Array.Copy(hashBytes, 0, salt, 0, 16);

      /* Compute the hash on the password the user entered */
      var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, 1000);
      var hash = pbkdf2.GetBytes(20);

      /* Compare the results */
      for (int i = 0; i < 20; i++)
      {
        if (hashBytes[i + 16] != hash[i])
        {
          return false;
        }
      }
      return true;
    }
  }
}