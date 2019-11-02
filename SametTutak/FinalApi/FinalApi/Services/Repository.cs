using System.Collections.Generic;
using System.Linq;
using FinalApi.Context;
using FinalApi.Interfaces;

namespace FinalApi.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly DataContext _dataContext;

        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool Delete(int id)
        {
            var kontrol = false;
            var deger = Find(id);

            if (deger != null)
            {
                _dataContext.Set<T>().Remove(deger);
                kontrol = true;
            }
            return kontrol;

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

        public List<T> List()
        {
            return _dataContext.Set<T>().ToList();
        }

        public T Update(T entity)
        {
            _dataContext.Set<T>().Update(entity);
            return entity;
        }
    }
}
