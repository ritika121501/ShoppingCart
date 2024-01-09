using ShoppingCart.Migrations;

namespace ShoppingCart.Repository
{
    public interface IRepository<T>where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Remove(T entity);

        void Save();
       
    }
}
