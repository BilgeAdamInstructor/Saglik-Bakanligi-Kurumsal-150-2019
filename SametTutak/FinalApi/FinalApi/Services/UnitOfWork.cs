using FinalApi.Context;
using FinalApi.Interfaces;

namespace FinalApi.Services
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DataContext _dataContext;

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
            userRepository = new UserRepository(_dataContext);
        }
        public IUserRepository userRepository { get; set; }

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
