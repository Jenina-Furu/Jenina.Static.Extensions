using System;
using System.Collections.Generic;
using System.Text;

namespace Jenina.Static.Extensions
{
    public static class DateTimeExtensions
    {      
        public static bool IsMinValue(this DateTime sourceDateTime)
        {
            var result = sourceDateTime == DateTime.MinValue;
            return result;
        }

        public static DateTime NextDay(this DateTime sourceDateTime)
        {
            var result = sourceDateTime.Date.AddDays(1);
            return result;
        }

        public static DateTime PreviousDay(this DateTime sourceDateTime)
        {
            var result = sourceDateTime.Date.AddDays(-1);
            return result;
        }

        public static DateTime GetFirstDayOfMonth(this DateTime sourceDateTime)
        {
            return sourceDateTime.AddDays(1 - sourceDateTime.Day).Date;
        }

        public static DateTime GetFirstDayOfNextMonth(this DateTime sourceDateTime)
        {
            return sourceDateTime.AddDays(1 - sourceDateTime.Day).Date.AddMonths(1);
        }

        public static DateTime GetFirstDayOfLastMonth(this DateTime sourceDateTime)
        {
            return sourceDateTime.AddDays(1 - sourceDateTime.Day).Date.AddMonths(-1);
        }

        public static DateTime GetLastDayOfMonth(this DateTime sourceDateTime)
        {
            return sourceDateTime.AddDays(1 - sourceDateTime.Day).Date.AddMonths(1).AddDays(-1);
        }

        public static DateTime GetSecondDayToLastOfMonth(this DateTime sourceDateTime)
        {
            return sourceDateTime.AddDays(1 - sourceDateTime.Day).Date.AddMonths(1).AddDays(-2);
        }

        public static DateTime CurrentMonthFirstDay(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, 1);
        }

        public static DateTime CurrentMonthLastDay(this DateTime dt)
        {
            return CurrentMonthFirstDay(dt).AddMonths(1).AddMilliseconds(-1);
        }

        public static DateTime CurrentDay(this DateTime sourceDateTime, double? hours = null)
        {
            var result = sourceDateTime.Date;
            if (hours.HasValue)
            {
                result = result.AddHours(hours.Value);
            }

            return result;
        }

        public static bool IsWeekend(this DateTime dt)
        {
            return dt.DayOfWeek == DayOfWeek.Saturday || dt.DayOfWeek == DayOfWeek.Sunday;
        }
    }
}
