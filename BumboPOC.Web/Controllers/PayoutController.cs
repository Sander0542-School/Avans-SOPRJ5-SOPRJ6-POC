using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BumboPOC.Web.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace BumboPOC.Web.Controllers
{
    public class PayoutController : Controller
    {
        public IActionResult Index()
        {

            
    
            return View(Data.Models.User.All());
        }

        public IActionResult Detail(int id)
        {
            var workedHours = WorkedHours.All().Where(wh => wh.UserId == id);

            var user = Data.Models.User.Get(id);

            return View(user);
        }
    }
}
