using System;
using System.ComponentModel.DataAnnotations;

namespace api.Models
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
		public string Password { get; set; }

		public DateTime Created { get; set; }

		//add movies props

		public User()
		{
			Created = DateTime.Now;
		}
	}
}