using FinalExam.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalExam.Service
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
            UserRepository = new UserRepository(_dataContext);
        }

        public void Dispose()
        {
            _dataContext.Dispose();
            
        }

        public IUserRepository UserRepository { get; set; }

        public int Complete()
        {
            return _dataContext.SaveChanges();
        }
    }
}
