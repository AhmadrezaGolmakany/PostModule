using _Utilities.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _Utilities.Infrastracture
{
    public class Repository<TKey, T> : IRepository<TKey, T> where T : class
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public bool Create(T model)
        {
            _context.Add<T>(model);
            return Save();
        }

        public bool Delete(T model)
        {
            _context.Remove<T>(model);
            return Save();
        }

        public bool Exist(Expression<Func<T, bool>> expression) =>
            _context.Set<T>().Any(expression);


        public IEnumerable<T> GetAll() =>
             _context.Set<T>().ToList();



        public IEnumerable<T> GetAllBy(Expression<Func<T, bool>> expression) =>
             _context.Set<T>().Where(expression).ToList();

        public IQueryable<T> GetAllByQuery(Expression<Func<T, bool>> expression) =>
             _context.Set<T>().Where(expression);

        public IQueryable<T> GetAllQuery() =>
             _context.Set<T>();

        public T GetById(TKey id) =>
            _context.Find<T>(id);

        public bool Save() =>
            _context.SaveChanges() >= 0 ? true : false;

    }
}
