﻿using ShoppingCart.Models;

namespace ShoppingCart.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
        void RemoveRange(IEnumerable<T> entity);
    }
}