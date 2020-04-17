using System.Threading.Tasks;
using api.Models;

namespace api.Repositories
{
	public interface IAuthRepository
	{
		Task<bool> DoesUserExist(string email);
		Task<User> Register(UserInput user);
	}
}