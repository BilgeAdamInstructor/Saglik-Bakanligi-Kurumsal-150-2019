using JwtFinalQuiz.Interfaces;

namespace JwtFinalQuiz.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly XContext _xcontext;

        public UnitOfWork(XContext xcontext)
        {
            _xcontext = xcontext;
            userRepository = new UserRepository(_xcontext);
        }

        public IUserRepository userRepository { get; set; }

        public void Dispose()
        {
            _xcontext.Dispose();
        }

        public int Flush()
        {
            return _xcontext.SaveChanges();
        }
    }
}
