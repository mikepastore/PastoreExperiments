using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgendaMinutesServiceLib
{


    public static class DateExtensions
    {     
        /// <summary>
        /// Returns 12:00am of the given day
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static DateTime GetMorningTime(this DateTime day)
        {
            return new DateTime(day.Year, day.Month, day.Day, 0, 0, 0);
        }

        public static bool IsValid(this DateTime date)
        {
            return date.Year > 1;
        }

        public static DateTime TryParseDate(this string dateString, DateTime? defaultReturn = null)
        {
            DateTime date = defaultReturn.GetValueOrDefault();
            DateTime.TryParse(dateString, out date);
            return date;
        }

    }
}
