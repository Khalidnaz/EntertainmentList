using System;
using System.ComponentModel.DataAnnotations;

namespace api.Models.DataModel
{

	/// <summary>
	/// A user for the app
	/// </summary>

	public class User
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		[Required]
		public string Email { get; set; }

		[Required]
		[StringLength(8, MinimumLength = 4, ErrorMessage = "You must specify a password between 4 and 8 characters")]
		public string Password { get; set; }

		public byte[] PasswordHash { get; set; }

		public byte[] PasswordSalt { get; set; }

		public DateTime Created { get; set; }

		public User()
		{
			Created = DateTime.Now;
		}
	}
}