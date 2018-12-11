using DAL.RepositoryPattern.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RepositoryPattern
{
    public interface IRestaurantRepository<T> where T : class
    {
        IQueryable<T> GetItems();
        T GetItemByID(int id);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
        Task SaveChangesAsync();
        void AddItem(T entity);
    }
}
