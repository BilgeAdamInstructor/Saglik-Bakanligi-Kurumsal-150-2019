using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApii
{
    public class UserManagementService : Repository<Users>, IUserManagementService
    {
        private DataContext dataContext; 

        public UserManagementService(DataContext dataContext):base(dataContext)
        {
            this.dataContext = dataContext;
        } 

        public bool IsValidUser(string username, string password)
        {
            return true;
        }
    }
}
