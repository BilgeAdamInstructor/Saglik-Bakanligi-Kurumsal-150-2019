using System;
using System.Collections.Generic;
using FinalExam_ulker.Web.Interfaces;
using FinalExam_ulker.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalExam_ulker.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var result = _unitOfWork.UserRepository.List();
            return new JsonResult(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return new JsonResult(_unitOfWork.UserRepository.Find(id));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post(int id, [FromBody] List<User> users)
        {
            foreach (var user in users)
            {
                var result = _unitOfWork.UserRepository.Find(user.Id);

                if (result == null)
                {
                    _unitOfWork.UserRepository.Insert(user);
                    _unitOfWork.Complete();
                }
            }

            return new JsonResult(users);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            if (id != user.Id) return BadRequest();
            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.Complete();
            return new JsonResult(user);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return new JsonResult(new Tuple<bool, int>(_unitOfWork.UserRepository.Delete(id), _unitOfWork.Complete()));
        }
    }
}