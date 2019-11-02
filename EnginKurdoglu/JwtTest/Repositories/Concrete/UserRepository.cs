using JwtTest.Models;
using JwtTest.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace JwtTest.Repositories.Concrete
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly DbSet<User> _userDbSet;

        public UserRepository(JwtTestDataContext context) : base(context)
        {
            _userDbSet = context.Users;
        }

        public void AddUser(User user)
        {
            if (_userDbSet.Find(user.Id) == null)
                _userDbSet.Add(user);
        }
    }
}
