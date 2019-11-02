using FinalApi.Context;
using FinalApi.Interfaces;
using FinalApi.Models;
using System.Linq;

namespace FinalApi.Services
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }
        public User FindUserName(string username)
        {
            return _dataContext.Set<User>().FirstOrDefault(a => a.username == username);
        }

    }
}
