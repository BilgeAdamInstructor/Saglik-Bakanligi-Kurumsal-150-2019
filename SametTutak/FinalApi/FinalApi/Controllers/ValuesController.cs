using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalApi.DTO;
using FinalApi.Interfaces;
using FinalApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public ValuesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public ActionResult Index([FromBody]List<JDto> jDto)
        {
            Console.WriteLine(jDto);

            foreach (var item in jDto)

            {
                User user = new User()
                {
                    firstName = item.firstName,
                    lastName = item.lastName,
                    username = item.username
                };
                var result = _unitOfWork.userRepository.FindUserName(user.username);
                if (result == null)
                {
                    _unitOfWork.userRepository.Insert(user);

                }
            }

            _unitOfWork.Complete();
            return new JsonResult(_unitOfWork.userRepository.List());
        }


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

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            User user =_unitOfWork.userRepository.Find(id);
            if (user !=null)
            {
                _unitOfWork.userRepository.Update(user);
                _unitOfWork.Complete();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var del = _unitOfWork.userRepository.Delete(id);
            if (del == true)
                _unitOfWork.Complete();
            return Get();
        }
    }
}
