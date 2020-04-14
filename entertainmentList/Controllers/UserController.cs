using System.Threading.Tasks;
using entertainmentList.Models.DataModel;
using entertainmentList.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace entertainmentList.Controllers
{
	[Route("/api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IAuthRepository _repo;

		public UserController(IAuthRepository repo)
		{
			_repo = repo;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register(NewUser user)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (await _repo.DoesUserExist(user.Email))
			{
				return BadRequest("Email already exist");
			}

			var createdUser = await _repo.Register(user);

			return Ok(createdUser);
		}
	}
}