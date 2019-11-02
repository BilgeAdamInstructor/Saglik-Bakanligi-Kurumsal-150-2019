using JwtFinalQuiz.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace JwtFinalQuiz.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        readonly XContext _xcontext;

        public Repository(XContext xcontext)
        {
            _xcontext = xcontext;
        }

        public bool Delete(int id)
        {
            var res = false;
            var x = Find(id);
            if (x != null)
            {
                _xcontext.Set<T>().Remove(x);
                res = true;
            }
            return res;
        }

        public T Find(int id)
        {
            return _xcontext.Set<T>().Find(id);
        }

        public T Insert(T ent)
        {
            _xcontext.Set<T>().Add(ent);
            return ent;
        }

        public List<T> List()
        {
            return _xcontext.Set<T>().ToList();
        }

        public T Update(T ent)
        {
            _xcontext.Set<T>().Update(ent);
            return ent;
        }
    }
}
