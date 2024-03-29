﻿using ShoppingCart.Models;
using System.Linq.Expressions;

namespace ShoppingCart.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(string? includeProperties = null);
        IEnumerable<T> GetAllWithFilter(Expression<Func<T, bool>>? filter, string? includeProperties = null);
        T Get(Expression<Func<T, bool>> filter);
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}
