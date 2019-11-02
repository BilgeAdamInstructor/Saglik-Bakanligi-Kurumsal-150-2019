using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApii
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _dataContext;

        public Repository(DataContext dbContext)
        {
            _dataContext = dbContext;
        }

        public IEnumerable<T> List()
        {
            return _dataContext.Set<T>().ToList();
        }

        public T Find(int id)
        {
            return _dataContext.Set<T>().Find(id);
        }

        public T Insert(T entity)
        {
            _dataContext.Set<T>().Add(entity);
            return entity;
        }

        public T Update(T entity)
        {
            _dataContext.Set<T>().Update(entity);
            return entity;
        }

        public bool Delete(int id)
        {
            var result = false;

            var entity = Find(id);

            if (entity != null)
            {
                _dataContext.Set<T>().Remove(entity);
                result = true;
            }

            return result;
        }
        public IQueryable<T> Query()
        {
            return _dataContext.Set<T>();
        }

        IQueryable<Users> IRepository<T>.Query()
        {
            throw new NotImplementedException();
        }
    }
}
