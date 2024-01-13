using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data;
using System.Linq.Expressions;

namespace ShoppingCart.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ShoppingCartContext _context;
        private DbSet<T> dbSet;

        public Repository(ShoppingCartContext context)
        {
            _context = context;
            this.dbSet = _context.Set<T>();
        }
        public void Delete(T entity)
        {
            dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if(!string.IsNullOrEmpty(includeProperties))
            {
                foreach(var prop in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(prop);
                }
            }
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

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
