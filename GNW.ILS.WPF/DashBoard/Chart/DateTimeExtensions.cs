using System;
using System.Globalization;

namespace Pervation.Presentation.DashBoard.Chart
{
    static class DateTimeExtensions
    {
        static readonly GregorianCalendar GregorianCalendar = new GregorianCalendar();
        public static int GetWeekOfMonth(this DateTime time)
        {
            DateTime first = new DateTime(time.Year, time.Month, 1);
            return time.GetWeekOfYear() - first.GetWeekOfYear() + 1;
        }

        static int GetWeekOfYear(this DateTime time)
        {
            return GregorianCalendar.GetWeekOfYear(time, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
        }
    }
}
