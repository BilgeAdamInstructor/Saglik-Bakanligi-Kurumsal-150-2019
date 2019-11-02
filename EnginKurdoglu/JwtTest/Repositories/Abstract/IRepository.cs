using System.Collections.Generic;

namespace JwtTest.Repositories.Abstract
{
    public interface IRepository<T> where T : class, new()
    {
        T Get(int id);
        List<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
