using JwtFinalQuiz.Models;

namespace JwtFinalQuiz.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User FindUser(string username);
    }
}
