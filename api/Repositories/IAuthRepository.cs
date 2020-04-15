using System.Threading.Tasks;
using entertainmentList.Models.DataModel;

namespace entertainmentList.Repositories
{
	public interface IAuthRepository
	{
		Task<bool> DoesUserExist(string email);
		Task<NewUser> Register(NewUser user);
	}
}