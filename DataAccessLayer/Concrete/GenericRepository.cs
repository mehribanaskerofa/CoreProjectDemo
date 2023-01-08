using DataAccessLayer.SqlServer.Abstract;
using DataAccessLayer.SqlServer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.SqlServer.Concrete
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T t)
        {
            using var c = new SqlServerContext();
            c.Remove(t);
            c.SaveChanges();
        }

        public T GetByID(int id)
        {
            using var c = new SqlServerContext();
            return c.Set<T>().Find(id);
        }

        public List<T> GetListAll(Expression<Func<T, bool>> filter = null)
        {
            using (var c = new SqlServerContext())
            {
                return filter == null ?
                    c.Set<T>().ToList() :
                c.Set<T>().Where(filter).ToList();
            }
        }
        //public List<T> GetListAll(Expression<Func<T, bool>> filter)
        //{
        //    using var c = new SqlServerContext();
        //    return c.Set<T>().Where(filter).ToList();
        //}

        public void Insert(T t)
        {
            using var c = new SqlServerContext();
            c.Add(t);
            c.SaveChanges();
        }

        public T GetByFilter(Expression<Func<T, bool>> filter = null)
        {
            using var c = new SqlServerContext();
            if (filter == null)
                return c.Set<T>().FirstOrDefault();
            else
                return c.Set<T>().FirstOrDefault(filter);
        }


        public void Update(T t)
        {
            using var c = new SqlServerContext();
            c.Update(t);
            c.SaveChanges();
        }

       
    }
}
