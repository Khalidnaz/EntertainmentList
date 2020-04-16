using System;
using System.Threading.Tasks;
using api.Models.DataModel;
using EntertainmentList.Repositories;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Resolvers;
using HotChocolate.Types;

// example https://github.com/ChilliCream/hotchocolate-examples/blob/master/workshop/src/Server/PureCodeFirst%2BEF/Users/UserMutations.cs

namespace EntertainmentList.Mutations
{
	[ExtendObjectType(Name = "Mutation")]
	public class UserMutations
	{
		private readonly IAuthRepository _repo;

		public UserMutations(IAuthRepository repo)
		{
			_repo = repo ?? throw new ArgumentNullException(nameof(repo));
		}

		/// <summary>
		/// Creates a new user.
		/// </summary>
		public async Task<User> AddNewUser(User user)
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
	}
}