using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BumboPOC.Web.Common.Extensions
{
    public static class DateTimeExtension
    {
        public static int WeekNumber(this DateTime date)
        {
            var day = (int)CultureInfo.CurrentCulture.Calendar.GetDayOfWeek(date);
            return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date.AddDays(4 - (day == 0 ? 7 : day)), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }
    }
}
