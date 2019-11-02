using JwtTest.Models;
using JwtTest.Repositories.Abstract;
using JwtTest.UnitOfWorks.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace JwtTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public UsersController(IUnitOfWork unitOfWork)
        {
            _userRepository = unitOfWork.UserRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("save")]
        public IActionResult SaveDetails([FromBody]UsersDTO userList)
        {
            if (userList != null)
            {
                foreach (var user in userList.Users)
                    _userRepository.AddUser(user);
                _unitOfWork.Complete();
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("echo")]
        public IActionResult Echo()
        {
            return Ok("echo");
        }

        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            return new JsonResult(_userRepository.GetAll());
        }
    }
}