using Microsoft.EntityFrameworkCore;
using NToastNotify;
using ShoppingCart.Data;
using ShoppingCart.Models;

namespace ShoppingCart.Repository
{
    public class Repository<T> : IRepository<T> where T : class

    {
        private readonly ShoppingCartContext _context;
        private DbSet<T> dbSet;


        
        public Repository(ShoppingCartContext context, IToastNotification toastNotification)
        {
            _context = context;
            this.dbSet = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void Insert(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Remove(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
