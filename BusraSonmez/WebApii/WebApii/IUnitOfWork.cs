using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApii
{
    public interface IUnitOfWork:IDisposable
    {
        IUserManagementService UserManagementService { get; set; }
        IAuthenticationService TokenAuthenticationService { get; set; }
        int Complete();
    } 
}
