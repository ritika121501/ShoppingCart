using ShoppingCart.Data;

namespace ShoppingCart.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ShoppingCartContext _context;

        public Repository(ShoppingCartContext context)
        {
            _context = context;
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
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
