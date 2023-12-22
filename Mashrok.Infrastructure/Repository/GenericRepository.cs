using Mashrok.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mashrok.Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext db;
        private readonly DbSet<T> table;
        public GenericRepository(ApplicationDbContext _db)
        {
            db = _db;
            table = db.Set<T>();
        }
        public void Delete(int id)
        {
            var t = table.Find(id);
            table.Remove(t);
        }

        public T First(Expression<Func<T, bool>> pridicate)
        {
            IQueryable<T> query = table;
            if (pridicate != null)
            {
                query.Where(pridicate);
            }
            return query.FirstOrDefault(pridicate);
        }

        public IList<T> Fitler(Expression<Func<T, bool>> pridicate, params string[] includes)
        {
            //  return table.Where(pridicate).ToList();
            IQueryable<T> query = table;
            if (pridicate != null)
            {
                query = query.Where(pridicate);
            }
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query.ToList();
        }
        public IList<T> Fitler(Expression<Func<T, bool>> pridicate)
        {
            //  return table.Where(pridicate).ToList();
            IQueryable<T> query = table;
            if (pridicate != null)
            {
                query = query.Where(pridicate);
            }

            return query.ToList();
        }

        public List<T> GetAll()
        {
            return table.ToList();
        }

        public List<T> GetAll(params string[] includes)
        {
            IQueryable<T> query = table;
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public T GetById(Expression<Func<T, bool>> filter, params string[] includes)
        {
            IQueryable<T> query = table;
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query.FirstOrDefault(filter);
        }

        public T GetByIdWithInclude(Expression<Func<T, bool>> filter, object id, string[] includes = null)
        {
            IQueryable<T> query = table;
            if (filter != null)
            {
                query.Where(filter);
            }
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query.FirstOrDefault();
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }


        public void Update(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
