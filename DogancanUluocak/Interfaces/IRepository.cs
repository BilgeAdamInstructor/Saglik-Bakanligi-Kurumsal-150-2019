using System.Collections.Generic;

namespace JwtExercise.Interfaces
{
    public interface IRepository<T> where T:class
    {
        List<T> List();
        T Insert(T entity);
        T Update(T entity);
        T Find(int id);
        bool Delete(int id);
    }
}
