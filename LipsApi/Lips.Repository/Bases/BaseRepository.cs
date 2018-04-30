using Lips.Domain.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Lips.Dal.Context;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using AutoMapper;

namespace Lips.Repository.Bases
{
    public class BaseRepository<T> : IDisposable, IBaseRepository<T>
        where T : Base
    {
        private BaseContext _context = null;

        public BaseContext Context
        {
            get { return _context == null ? _context = new BaseContext() : _context; }
            set { _context = value; }
        }

        public virtual void Add(T entity)
        {
            Set.Add(entity);
        }

        public virtual void AddOrUpdate(T entity)
        {
            var item = Query.FirstOrDefault(p => p.Id == entity.Id);
            if (item != null)
                Update(entity);
            else
                Add(entity);
        }

        public bool Any(Expression<Func<T,bool>> predicate)
        {
            return Query.Any(predicate);
        }

        public void Delete(T entity)
        {
            Set.Remove(entity);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && _context != null)
                _context.Dispose();
        }

        public T First(Expression<Func<T, bool>> predicate)
        {
            return Query.First(predicate);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return Query.FirstOrDefault(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return Query.AsEnumerable();
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public T Single(Expression<Func<T, bool>> predicate)
        {
            return Query.Single(predicate);
        }

        public T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return Query.SingleOrDefault(predicate);
        }

        public virtual void Update(T entity)
        {
            var item = Query.First(p => p.Id == entity.Id);
            Mapper.Map(entity, item);
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return Query.Where(predicate);
        }

        protected DbSet<T> Set { get { return Context.Set<T>(); } }

        protected DbQuery<T> Query { get { return (DbQuery<T>)Set; } }

       


    }
}
