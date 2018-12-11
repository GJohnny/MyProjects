using DAL.RepositoryPattern.Context;
using DAL.RepositoryPattern.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RepositoryPattern
{
    public class RestaurantRepository<T> : IRestaurantRepository<T> where T : class
    {
        private readonly AppIdentityDbContext _context;
        public RestaurantRepository(AppIdentityDbContext context)
        {
            _context = context;
        }

        public void AddItem(T entity)
        {
            _context.Add<T>(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public T GetItemByID(int id)
        {
            return _context.Find<T>(id);
        }

        public IQueryable<T> GetItems()
        {
            return _context.Set<T>();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _context.Entry<T>(entity).CurrentValues.SetValues(entity);
            SaveChanges();
        }
    }
}
