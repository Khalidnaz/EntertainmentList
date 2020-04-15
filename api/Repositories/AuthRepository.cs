using System;
using System.Threading.Tasks;
using EntertainmentList.Models;
using EntertainmentList.Models.DataModel;
using Microsoft.EntityFrameworkCore;

namespace EntertainmentList.Repositories
{
	public class AuthRepository : IAuthRepository
	{
		private readonly ApplicationDbContext _context;

		public AuthRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<bool> DoesUserExist(string email)
		{
			if (await _context.Users.AnyAsync(x => x.Email == email))
			{
				return true;
			}
			return false;
		}

		public async Task<User> Register(User user)
		{
			byte[] passwordHash;
			byte[] passwordSalt;

			CreatePasswordHash(user.Password, out passwordHash, out passwordSalt);
			user.PasswordHash = passwordHash;
			user.PasswordSalt = passwordSalt;
			user.Password = String.Empty;

			await _context.Users.AddAsync(user);
			await _context.SaveChangesAsync();
			return user;
		}

		private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
		{
			using (var salt = new System.Security.Cryptography.HMACSHA512())
			{
				passwordSalt = salt.Key;
				passwordHash = salt.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
			}
		}

		private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
		{
			using (var salt = new System.Security.Cryptography.HMACSHA512(passwordSalt))
			{
				var computedHash = salt.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

				for (int i = 0; i < computedHash.Length; i++)
				{
					if (computedHash[i] != passwordHash[i])
					{
						return false;
					}
				}
			}
			return true;
		}
	}
}