using JwtTest.Models;

namespace JwtTest.Repositories.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        void AddUser(User user);
    }
}
