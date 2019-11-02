using System;

namespace FinalApi.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IUserRepository userRepository { get; set; }
        int Complete();
    }
}
