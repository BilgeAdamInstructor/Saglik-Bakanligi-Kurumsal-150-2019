using System;

namespace JwtExercise.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IUserRepository userRepository { get; set; }
        int Clean();
    }
}
