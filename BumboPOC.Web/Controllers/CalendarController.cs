using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BumboPOC.Web.Common.Extensions;
using BumboPOC.Web.Data.Models;
using BumboPOC.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BumboPOC.Web.Controllers
{
    public class CalendarController : Controller
    {
        public IActionResult Index(int? id)
        {
            var model = new List<UserCalendarsModel>();

            var users = Data.Models.User.All();
            var calendars = Data.Models.Calendar.All();

            foreach (var user in users)
            {
                model.Add(new UserCalendarsModel
                {
                    User = user,
                    Calendars = calendars.Where(c => c.UserId == user.Id).Where(c => c.Date.WeekNumber() == (id ?? 1)).ToList()
                });
            }

            return View(model);
        }
    }
}
