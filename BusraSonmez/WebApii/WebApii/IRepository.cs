﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApii
{
   public interface IRepository<T> where T : class
    {
        IEnumerable<T> List();
        T Find(int id);
        T Insert(T entity);
        T Update(T entity);
        bool Delete(int id);
        IQueryable<Users> Query();

    }
}
