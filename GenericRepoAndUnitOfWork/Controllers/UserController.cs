using GenericRepoAndUnitOfWork.Core.IConfiguration;
using GenericRepoAndUnitOfWork.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenericRepoAndUnitOfWork.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private ILogger<UserController> logger;
		private IUnitOfWork unitOfWork;

		public UserController(ILogger<UserController> _logger, IUnitOfWork _unitOfWork)
		{
			this.logger = _logger;
			this.unitOfWork = _unitOfWork;
		}

		[HttpGet]
		[Route("GetAllUsers")]
		public async Task<IActionResult> GetAll()
		{
			var allUsers = await unitOfWork.Users.GetAllAsync();
			return Ok(allUsers);
		}

		[HttpGet]
		[Route("GetUser/{userID}")]
		public async Task<IActionResult> GetUserItem(Guid userID)
		{
			var user = await unitOfWork.Users.GetByIdAsync(userID);
			if(user == null)
				return NotFound();
			return Ok(user);
		}

		[HttpPost]
		[Route("CreateNewUser")]
		public async Task<IActionResult> CreateUser(User user)
		{
			if(ModelState.IsValid)
			{
				user.UserId = Guid.NewGuid();
				
				await unitOfWork.Users.AddAsync(user);
				await unitOfWork.CompleteAsync();

				return CreatedAtAction("GetUserItem", new {user.UserId}, user);
			}

			return new JsonResult("Get An Error Creating New User")
			{ StatusCode = 500 };
		}

		[HttpPut]
		[Route("UpdateUser/{userId}")]
		public async Task<IActionResult> Update(Guid userId, User user)
		{
			if(userId != user.UserId) 
				return BadRequest();

			await unitOfWork.Users.UpdateAsync(user);
			await unitOfWork.CompleteAsync();

			return Ok(user);
		}

		[HttpDelete]
		[Route("DeleteUser/{userId}")]
		public async Task<IActionResult> Delete(Guid userId)
		{
			//User user = await unitOfWork.Users.GetByIdAsync(userId);
			IEnumerable<User> userList = await unitOfWork.Users.FindAsync(x => x.UserId == userId);
			User user = userList.FirstOrDefault();

			if(user == null)
				return BadRequest();

			await unitOfWork.Users.DeleteAsync(userId);
			await unitOfWork.CompleteAsync();

			return Ok(user);
		}
	}
}
