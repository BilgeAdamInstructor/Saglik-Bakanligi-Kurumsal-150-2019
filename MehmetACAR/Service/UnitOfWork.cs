using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PREFinalExam1.Interface;

namespace PREFinalExam1.Service
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AContext _aContext;

        public UnitOfWork(AContext aContext)
        {
            _aContext = aContext;
            UserRepository = new UserRepository(_aContext);
        }

        public void Dispose()
        {
            _aContext.Dispose();
        }

        public IUserRepository UserRepository { get; set; }

        public int Complete()
        {
            return _aContext.SaveChanges();
        }
    }
}
