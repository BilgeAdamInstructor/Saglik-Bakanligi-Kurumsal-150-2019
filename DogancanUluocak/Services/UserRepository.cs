using JwtExercise.Interfaces;
using JwtExercise.Models;
using System.Linq;

namespace JwtExercise.Services
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        readonly XContext _xcontext;

        public UserRepository(XContext xcontext) : base(xcontext)
        {
            _xcontext = xcontext;
        }

        public User FindUsername(string username)
        {
            return _xcontext.Set<User>().FirstOrDefault(a=>a.username == username);
        }
    }
}
