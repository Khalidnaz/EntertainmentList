using System.ComponentModel.DataAnnotations;
using HotChocolate;

namespace api.Models.Users
{
	public class UserInput
	{
		[GraphQLNonNullType]
		public string FirstName { get; set; }

		[GraphQLNonNullType]
		public string LastName { get; set; }

		[GraphQLNonNullType]
		public string Email { get; set; }

		[GraphQLNonNullType]
		public string Password { get; set; }
	}
}