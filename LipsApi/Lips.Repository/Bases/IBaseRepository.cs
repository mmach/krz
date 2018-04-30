using Lips.Domain.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Repository
{
    public interface IBaseRepository<T> : IDisposable where T : Base 
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Where(Expression<Func<T, bool>> predicate);
        T Single(Expression<Func<T, bool>> predicate);
        T SingleOrDefault(Expression<Func<T, bool>> predicate);
        T First(Expression<Func<T, bool>> predicate);
        T FirstOrDefault(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        void AddOrUpdate(T entity);
        void SaveChanges();
        bool Any(Expression<Func<T,bool>> predicate);
    }
}
