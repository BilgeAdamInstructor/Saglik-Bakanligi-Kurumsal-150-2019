using System.Collections.Generic;
using JwtFinalQuiz.DTO;
using JwtFinalQuiz.Interfaces;
using JwtFinalQuiz.Models;
using Microsoft.AspNetCore.Mvc;

namespace JwtFinalQuiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;

        public ValuesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            return new JsonResult(_unitOfWork.userRepository.List());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return new JsonResult(_unitOfWork.userRepository.Find(id));
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] List<UserDto> userDtos)
        {
            foreach (var item in userDtos)
            {
                User user = new User()
                {
                    firstname = item.firstname,
                    lastname = item.lastname,
                    username = item.username
                };

                var res = _unitOfWork.userRepository.FindUser(user.username);
                if (res == null)
                    _unitOfWork.userRepository.Insert(user);
            }
            _unitOfWork.Flush();
            return Get();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            var find = _unitOfWork.userRepository.Find(id);
            if (find != null)
            {
                _unitOfWork.userRepository.Update(find);
            }
            _unitOfWork.Flush();
            Get();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var res = _unitOfWork.userRepository.Delete(id);
            if (res == true)
                _unitOfWork.Flush();
            return Get();
        }
    }
}
