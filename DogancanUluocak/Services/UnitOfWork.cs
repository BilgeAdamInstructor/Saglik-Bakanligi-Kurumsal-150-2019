using JwtExercise.Interfaces;

namespace JwtExercise.Services
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

        public int Clean()
        {
            return _xcontext.SaveChanges();
        }

        public void Dispose()
        {
            _xcontext.Dispose();
        }
    }
}
