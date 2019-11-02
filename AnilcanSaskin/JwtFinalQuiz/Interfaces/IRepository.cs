using System.Collections.Generic;

namespace JwtFinalQuiz.Interfaces
{
    public interface IRepository<T> where T:class
    {
        List<T> List();
        T Insert(T ent);
        T Update(T ent);
        T Find(int id);
        bool Delete(int id);
    }
}
