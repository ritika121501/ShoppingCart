using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data;

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
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
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

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
