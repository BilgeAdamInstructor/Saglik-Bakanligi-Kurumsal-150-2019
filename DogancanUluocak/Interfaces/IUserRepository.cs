using JwtExercise.Models;

namespace JwtExercise.Interfaces
{
    public interface IUserRepository:IRepository<User>
    {
        User FindUsername(string username);
    }
}
