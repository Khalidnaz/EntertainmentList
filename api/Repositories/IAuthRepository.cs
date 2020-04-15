using System.Threading.Tasks;
using EntertainmentList.Models.DataModel;

namespace EntertainmentList.Repositories
{
	public interface IAuthRepository
	{
		Task<bool> DoesUserExist(string email);
		Task<User> Register(User user);
	}
}