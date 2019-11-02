using JwtTest.Repositories.Abstract;
using JwtTest.Repositories.Concrete;
using JwtTest.UnitOfWorks.Abstract;

namespace JwtTest.UnitOfWorks.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JwtTestDataContext _context;

        public UnitOfWork(JwtTestDataContext context)
        {
            _context = context;
        }

        private IUserRepository userRepository;
        public IUserRepository UserRepository => userRepository ?? (userRepository = new UserRepository(_context));

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
