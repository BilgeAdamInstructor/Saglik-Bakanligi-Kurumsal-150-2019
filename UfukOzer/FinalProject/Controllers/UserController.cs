using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Interfaces;
using FinalProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public class JDto
        {
            public int id { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string username { get; set; }
            public object password { get; set; }
            public object token { get; set; }
        }
        [HttpGet]
        [Route("receive")]
        public IActionResult Receive()
        {
            var result = _unitOfWork.UserRepository.GetAll();
            return new JsonResult(result);
        }
        [HttpPost]
        [Route("index")]
        public void Index([FromBody]List<JDto> jDto)
        {
            Console.WriteLine(jDto);

            for (int i = 0; i < jDto.Count; i++)
            {
                User user = new User()
                {
                    UserId = jDto[i].id,
                    firstName = jDto[i].firstName,
                    lastName = jDto[i].lastName,
                    username = jDto[i].username
                };
                

                var result = _unitOfWork.UserRepository.Get(user.UserId);
                if (result == null)
                {
                    _unitOfWork.UserRepository.Add(user);
                }
            }
            
        }
    }
}