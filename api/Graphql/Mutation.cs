using System.Threading.Tasks;
using api.Models;
using api.Repositories;
using HotChocolate;
using HotChocolate.Execution;

namespace api.Graphql
{
	public class Mutation
	{
		private readonly IAuthRepository _repo;

		public Mutation(IAuthRepository repo)
		{
			_repo = repo;
		}

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
	}
}