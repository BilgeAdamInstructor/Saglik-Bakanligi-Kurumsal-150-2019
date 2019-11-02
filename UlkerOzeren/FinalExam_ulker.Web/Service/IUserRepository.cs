using FinalExam_ulker.Web.Context;
using FinalExam_ulker.Web.Interfaces;
using FinalExam_ulker.Web.Models;

namespace FinalExam_ulker.Web.Service
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
