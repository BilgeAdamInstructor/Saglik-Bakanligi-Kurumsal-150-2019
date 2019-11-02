using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApii
{
   public interface IUserManagementService: IRepository<Users>
    {
        bool IsValidUser(string username, string password);
    }
}
