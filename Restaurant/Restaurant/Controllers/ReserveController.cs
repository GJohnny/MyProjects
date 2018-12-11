using BusinessLogic;
using DAL.RepositoryPattern;
using DAL.RepositoryPattern.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Features.Alerts;
using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Controllers
{
    public class ReserveController : Controller
    {
        private readonly IBusinessLogic _logic;
        private readonly AlertService _alertService;

        public ReserveController(IBusinessLogic logic, AlertService alertService)
        {
            _logic = logic;
            _alertService = alertService;
        }


        [HttpPost]
        [Authorize(Roles="Admin")]
        public IActionResult Reserve(ReserveViewModel model)
        {
            if (ModelState.IsValid)
            {
                DateTime dateTime = model.Date + model.Time.TimeOfDay;
                int tableID = -1;
                string username = User.Identity.Name;

                if (_logic.Reserve(dateTime, model.BranchName, model.Persons, username, out tableID))
                {
                    _alertService.Success($"Congratulations! Your Reserve was successfull/n" +
                        $"Your Table number is {tableID}", true);

                    //ViewBag.Message = $"Congratulations! Your Reserve was successfull/n" +
                    //    $"Your Table number is {tableID}";
                    return View();
                }

                _alertService.Success($"Sorry, we don't have available tables for " +
                                      $"now at this Branch. Please try again later!", true);
                //ViewBag.Message = $"Sorry, we don't have available tables for" +
                //                  $" now at this Branch. Please try again later!";
                return View();
            }
            return View();
        }

        public IActionResult Reserve()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}