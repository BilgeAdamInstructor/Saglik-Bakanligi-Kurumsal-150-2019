using System.Collections.Generic;

namespace FinalExam_ulker.Web.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> List();
        T Find(int id);
        T Insert(T entity);
        T Update(T entity);
        bool Delete(int id);

    }
}
