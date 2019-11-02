using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PREFinalExam1.Models;


namespace PREFinalExam1.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        bool UserCheck(int id);
       
    }
}
