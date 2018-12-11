using DAL.RepositoryPattern.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IBusinessLogic
    {
        IEnumerable<Menu> GetMenuItemsByCategory(string category);
        IEnumerable<Menu> GetMenuItemsSorted(string sortBy);
        bool Reserve(DateTime reserveDate, string branchName,int persons, string username, out int tableId);
        Task DeleteReservation();
    }
}
