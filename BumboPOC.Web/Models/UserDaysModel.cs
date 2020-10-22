﻿using BumboPOC.Web.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BumboPOC.Web.Models
{
    public class UserDaysModel
    {

        public User User { get; set; }

        public DayOfWeek[] DaysOfWeek = new DayOfWeek[]
        {
            DayOfWeek.Monday,
            DayOfWeek.Tuesday,
            DayOfWeek.Wednesday,
            DayOfWeek.Thursday,
            DayOfWeek.Friday,
            DayOfWeek.Saturday,
            DayOfWeek.Sunday
        };
    }
}
