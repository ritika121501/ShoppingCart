using ShoppingCart.Migrations;

namespace ShoppingCart.Repository
{
    public interface IRepository<T>where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int ID);
        void Insert(T Entity);
        void Update(T Entity);
        void Delete(int ID);


    }
}
