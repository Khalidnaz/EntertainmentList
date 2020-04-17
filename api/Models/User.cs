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
		public Guid Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Email { get; set; }

		public string Password { get; set; }

		public DateTime Created { get; set; }

		//add movies props
		//public IEnumerable MyMovies { get; set; }

		public User()
		{
			Created = DateTime.Now;
		}
	}
}