using System;

namespace JwtFinalQuiz.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IUserRepository userRepository { get; set; }
        int Flush(); //belleği temizler.
    }
}
