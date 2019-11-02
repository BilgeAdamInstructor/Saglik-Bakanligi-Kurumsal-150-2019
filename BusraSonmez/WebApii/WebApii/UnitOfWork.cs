using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApii
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;
        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
           UserManagementService = new UserManagementService(dataContext);            
        }

        public IUserManagementService UserManagementService { get; set; }
        public IAuthenticationService TokenAuthenticationService { get; set; } 
        public int Complete()
        {
            return _dataContext.SaveChanges();
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}
