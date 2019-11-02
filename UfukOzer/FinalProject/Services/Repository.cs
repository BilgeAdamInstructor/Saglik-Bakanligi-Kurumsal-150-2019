using FinalProject.Datas;
using FinalProject.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly DataContext _dataContext;

        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public T Add(T entity)
        {
            _dataContext.Set<T>().Add(entity);
            _dataContext.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            T entity = Get(id);
            _dataContext.Set<T>().Remove(entity);
        }

        public T Get(int id)
        {
            return _dataContext.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dataContext.Set<T>().ToList();
        }

        public T Update(int id)
        {
            T entity = Get(id);
            _dataContext.Set<T>().Update(entity);
            return entity;
        }
    }
}
