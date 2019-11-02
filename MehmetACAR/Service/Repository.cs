using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PREFinalExam1.Interface;

namespace PREFinalExam1.Service
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AContext _aContext;

        public Repository(AContext aContext)
        {
            _aContext = aContext;
        }

        public IEnumerable<T> List()
        {
            return _aContext.Set<T>().ToList();
        }

        public T Find(int id)
        {
            return _aContext.Set<T>().Find(id);
        }

        public T Insert(T entity)
        {
            _aContext.Set<T>().Add(entity);
            return entity;
        }

        public T Update(T entity)
        {
            _aContext.Set<T>().Update(entity);
            return entity;
        }

        public bool Delete(int id)
        {
            var result = false;

            var entity = Find(id);

            if (entity != null)
            {
                _aContext.Set<T>().Remove(entity);
                result = true;
            }

            return result;
        }

        public IQueryable<T> Query()
        {
            return _aContext.Set<T>();
        }
    }
}
