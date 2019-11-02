using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PREFinalExam1.Interface;
using PREFinalExam1.Models;
namespace PREFinalExam1.Service
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly AContext _aContext;

        public UserRepository(AContext aContext) : base(aContext)
        {
            _aContext = aContext;
        }

        public bool UserCheck(int id)
        {
            bool result = false;
            User user = _aContext.Users.Find(id);

            if (user != null) result = true;

            return result;
        }
    }
}
