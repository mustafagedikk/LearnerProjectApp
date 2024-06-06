using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        Context c = new Context();
        DbSet<T> _object;

        public GenericRepository()
        {
            _object = c.Set<T>();
        }

        public void Delete(T p)
        {
            var deletedEntry = c.Entry(p);
            deletedEntry.State = EntityState.Deleted;
            c.SaveChanges();

        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

     

        public void Insert(T p)
        {
            var addedEntry = c.Entry(p);
            addedEntry.State = EntityState.Added;
            c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T p)
        {
            var updateState = c.Entry(p);
            updateState.State = EntityState.Modified;
            c.SaveChanges();
        }
    }
}
