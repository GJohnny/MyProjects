using Microsoft.AspNetCore.Mvc;
using Restaurant.Features.Alerts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.ViewComponents
{
    public class AlertsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<Alert> alerts = TempData.ContainsKey(Alert.TempDataKey)
                ? (List<Alert>)TempData[Alert.TempDataKey]
                : new List<Alert>();

             return View(alerts);
        }
    }
}
