using FinalExam_ulker.Web.Context;
using FinalExam_ulker.Web.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FinalExam_ulker.Web.Service
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _dataContext;

        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext.Set<T>();
        }


        public IEnumerable<T> List()
        {
            return _dataContext.ToList();
        }

        public T Find(int id)
        {
            return _dataContext.Find(id);
        }

        public T Insert(T entity)
        {
            _dataContext.Add(entity);
            return entity;
        }

        public T Update(T entity)
        {
            _dataContext.Update(entity);
            return entity;
        }

        public bool Delete(int id)
        {
            var result = false;

            var entity = Find(id);

            if (entity != null)
            {
                _dataContext.Remove(entity);
                result = true;
            }

            return result;
        }

    }
}
