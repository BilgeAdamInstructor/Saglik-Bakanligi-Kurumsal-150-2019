using FinalApi.Models;

namespace FinalApi.Interfaces
{
    public interface IUserRepository:IRepository<User>
    {
        User FindUserName(string username);
 
    }
}
