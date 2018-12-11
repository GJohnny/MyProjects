using DAL.RepositoryPattern;
using DAL.RepositoryPattern.Context;
using DAL.RepositoryPattern.Entities;
using DAL.RepositoryPattern.IdentityEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Logic : IBusinessLogic
    {
        private readonly IRestaurantRepository<Menu> _menuRepository;
        private readonly IRestaurantRepository<Table> _tableRespository;
        private readonly IRestaurantRepository<Branch> _branchRepository;
        private readonly IRestaurantRepository<User> _userRepository;
        private readonly IRestaurantRepository<Reserve> _reserveRepository;

        public Logic(IRestaurantRepository<Menu> menu
            , IRestaurantRepository<Table> table
            , IRestaurantRepository<Branch> branch
            , IRestaurantRepository<User> user
            , IRestaurantRepository<Reserve> reserve)
        {
            _menuRepository = menu;
            _tableRespository = table;
            _branchRepository = branch;
            _userRepository = user;
            _reserveRepository = reserve;
        }


        public IEnumerable<Menu> GetMenuItemsByCategory(string category)
        {
            IEnumerable<Menu> menuList = _menuRepository.GetItems().Where(mi => mi.Category == category);
            return menuList;
        }

        public IEnumerable<Menu> GetMenuItemsSorted(string sortBy)
        {
            IEnumerable<Menu> menuList = null;

            if (sortBy == "Name")
            {
                menuList = _menuRepository.GetItems().OrderBy(mi => mi.Name);
            }
            else
            {
                menuList = _menuRepository.GetItems().OrderBy(mi => mi.Price);
            }

            return menuList;
        }

        public bool Reserve(DateTime reserveDate, string branchName, int persons, string username, out int tableId)
        {
            tableId = -1;
            Branch branch = _branchRepository.GetItems()
                             .First(b => b.Name == branchName);

            List<int> tableIdFromBranch = branch.Tables.Where(t => t.Capacity >= persons)
                        .Select(t => t.Id).ToList();

            List<int> tableIdFromReserve = _reserveRepository.GetItems()
                        .Where(r => r.IsDeleted == false && 
                                    r.Date.Day == reserveDate.Day && 
                                    r.Table.BranchId == branch.Id)
                        .Select(r => r.TableId).ToList();

            List<int> result = tableIdFromBranch.Where(x => !tableIdFromReserve.Any(r => r == x)).ToList();

            if (result.Count > 0)
            {
                tableId = result[0];
                User user = _userRepository.GetItems().Where(u => u.UserName == username).First();
                Table table = _tableRespository.GetItemByID(tableId);
                Reserve reserve = new Reserve
                {
                    User = user,
                    Table = table,
                    Date = reserveDate
                };
                _reserveRepository.AddItem(reserve);
                _reserveRepository.SaveChanges();
                return true;
            }
            return false;
        }
        public async Task DeleteReservation()
        {
            await Task.Run(() =>
            {
                while(true)
                {
                    Thread.Sleep(300000);
                    List<Reserve> reserves = _reserveRepository.GetItems()
                        .Where(r => r.IsDeleted == false && r.Date < DateTime.Now).ToList();

                    foreach (Reserve reserve in reserves)
                    {
                        reserve.IsDeleted = true;
                        _reserveRepository.Update(reserve);
                    }
                }
            });
        }
    }
}
