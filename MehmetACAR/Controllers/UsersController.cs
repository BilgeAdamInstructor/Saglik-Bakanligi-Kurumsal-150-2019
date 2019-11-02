using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PREFinalExam1.Models;

namespace PREFinalExam1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly Interface.IUnitOfWork _unitOfWork;

        public UsersController(Interface.IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("GetUser/{id}")]
        public IActionResult GetUser(int id)
        {
            User result = _unitOfWork.UserRepository.Find(id);
            return new JsonResult(result);
        }
        [Route("DeleteUserById/{id}")]
        public IActionResult DeleteUserById(int id)
        {
            bool result =  _unitOfWork.UserRepository.Delete(id);
            _unitOfWork.Complete();
            return new JsonResult(result);
        }

        [Route("SelectUserbyUserName/{UserName}")]
        public IActionResult SelectUserbyUserName(string UserName)
        {        
            IQueryable<User> users = _unitOfWork.UserRepository.Query();
            IQueryable<User> result = users.Where(q => q.username == UserName);
            return new JsonResult(result);
        }

        [Route("UpdateUserbyLastName/{id}/{LastName}")]
        public IActionResult UpdateUserbyLastName(int id,string LastName)
        {
            User user = _unitOfWork.UserRepository.Find(id);
            user.lastName = LastName;
            _unitOfWork.Complete();
            return new JsonResult(user);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return new JsonResult(_unitOfWork.UserRepository.List());
        }

        [HttpPost]
        public IActionResult PostAllUsers([FromBody] User[] users)
        {
            List<User> tamamlanan = new List<User>();
            List<User> hataAlinan = new List<User>();
            List<User> sistemdeKayitliKullanicilar = new List<User>();

            dynamic expResult = new ExpandoObject();
 
            foreach (var user in users)
            {
                try
                {
                    if (_unitOfWork.UserRepository.UserCheck(user.id))
                    {
                        sistemdeKayitliKullanicilar.Add(user);
                    }
                    else
                    {
                        _unitOfWork.UserRepository.Insert(user);
                        _unitOfWork.Complete();
                        tamamlanan.Add(user);
                    }
                }
                catch (Exception ee)
                {
                    hataAlinan.Add(user);
                }
            }
            _unitOfWork.Complete();
            expResult.Tamamlanan = tamamlanan;
            expResult.HataAlinan = hataAlinan;
            expResult.SistemdeKayitliOlanlar = sistemdeKayitliKullanicilar;

            return new JsonResult(expResult);
        }
    }
}
