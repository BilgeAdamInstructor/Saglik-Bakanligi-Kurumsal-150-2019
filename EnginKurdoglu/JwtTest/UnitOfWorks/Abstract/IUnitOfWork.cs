using JwtTest.Repositories.Abstract;
using System;

namespace JwtTest.UnitOfWorks.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();
        IUserRepository UserRepository { get; }

    }
}
