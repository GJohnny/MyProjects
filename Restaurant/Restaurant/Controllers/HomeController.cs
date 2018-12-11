using BusinessLogic;
using DAL.RepositoryPattern;
using DAL.RepositoryPattern.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBusinessLogic _logic;
        private readonly IRestaurantRepository<Menu> _menuRepository;
        private readonly IRestaurantRepository<Table> _tableRepository;
        private readonly IRestaurantRepository<Branch> _branchRepository;

        public HomeController(IRestaurantRepository<Menu> menuRepository,
                              IBusinessLogic logic,
                              IRestaurantRepository<Table> table,
                              IRestaurantRepository<Branch> branch)
        {
            _menuRepository = menuRepository;
            _logic = logic;
            _tableRepository = table;
            _branchRepository = branch;
        }
        public IActionResult Index()
        {
            ViewBag.Branches = _branchRepository.GetItems();
            return View();
        }
        public IActionResult Menu()
        {
            IEnumerable<Menu> menuList = _menuRepository.GetItems();
            return View(menuList);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Menu menu)
        {
            if (ModelState.IsValid)
            {
                _menuRepository.AddItem(menu);
                _menuRepository.SaveChanges();
                return RedirectToAction("Menu");
            }
            return RedirectToAction("Add");
        }

        public IActionResult AddTable()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTable(Table table)
        {
            if (ModelState.IsValid)
            {
                Branch branch = _branchRepository.GetItems().FirstOrDefault(b => b.Name == table.Branch.Name);
                branch.Tables.Add(table);
                _branchRepository.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("AddTable");
        }

        public IActionResult OpenBranch()
        {
            return View();
        }

        [HttpPost]
        public IActionResult OpenBranch(Branch branch)
        {
            if (ModelState.IsValid)
            {
                _branchRepository.AddItem(branch);
                _branchRepository.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("OpenBranch");
        }

        public IActionResult MenuSorted(string criteria)
        {
            IEnumerable<Menu> menuList = _logic.GetMenuItemsSorted(criteria);
            return PartialView("_MenuItemAjax", menuList);
        }

    }
}