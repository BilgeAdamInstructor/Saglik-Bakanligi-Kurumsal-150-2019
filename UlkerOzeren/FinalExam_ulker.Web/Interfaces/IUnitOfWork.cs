using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalExam_ulker.Web.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();
        IUserRepository UserRepository { get; set; }
    }
}
