using JwtTest.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace JwtTest.Repositories.Concrete
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly DbSet<T> _dbSet;

        public Repository(JwtTestDataContext context)
        {
            _dbSet = context.Set<T>();
        }
        void IRepository<T>.Add(T entity)
        {
            _dbSet.Add(entity);
        }

        void IRepository<T>.Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        T IRepository<T>.Get(int id)
        {
            return _dbSet.Find(id);
        }

        System.Collections.Generic.List<T> IRepository<T>.GetAll()
        {
            return _dbSet.ToList();
        }

        void IRepository<T>.Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
