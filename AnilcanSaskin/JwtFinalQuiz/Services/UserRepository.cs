using JwtFinalQuiz.Interfaces;
using JwtFinalQuiz.Models;
using System.Linq;

namespace JwtFinalQuiz.Services
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        readonly XContext _xcontext;

        public UserRepository(XContext xcontext) : base(xcontext)
        {
            _xcontext = xcontext;
        }

        public User FindUser(string username)
        {
            return _xcontext.Set<User>().FirstOrDefault(a => a.username == username);
        }
    }
}
