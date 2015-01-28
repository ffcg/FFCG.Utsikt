using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace FFCG.Utsikt.Web.Util
{
    public interface ICalendarCreator
    {
        Month CreateCalendarMonth(DateTime month);
        Month CreateCalendarMonth(DateTime month, List<DateTime> occupiedDates);
        Week CreateCalendarWeek(DateTime week);
        DateTime GetStartDayOfWeek(DateTime week);
    }

    public class CalendarCreator : ICalendarCreator
    {
        public Month CreateCalendarMonth(DateTime month)
        {
            var week = CreateCalendarWeek(new DateTime(month.Year,month.Month,1));
            var lastDayOfMonth = DateTime.DaysInMonth(month.Year, month.Month);
            var returnMonth = new Month();
            returnMonth.Weeks.Add(week);
            while (week.Days[6].Date.Month==month.Month&&week.Days[6].Date.Day!=lastDayOfMonth)
            {
                week = CreateCalendarWeek(week.Days[6].Date.AddDays(1));
                returnMonth.Weeks.Add(week);
            }
            return returnMonth;
        }

        public Month CreateCalendarMonth(DateTime month, List<DateTime> occupiedDates)
        {
            var returnMonth = CreateCalendarMonth(month);
            foreach (var week in returnMonth.Weeks)
            {
                foreach (var day in week.Days)
                {
                    day.IsOccupied = occupiedDates.Any(d=>d.Day==day.Date.Day&&d.Month==day.Date.Month);
                }
            }
            return returnMonth;
        }

        public Week CreateCalendarWeek(DateTime week)
        {
            var startDayOfWeek = GetStartDayOfWeek(week);
            var returnWeek = new Week();
            returnWeek.WeekNumber = GetIso8601WeekOfYear(week);
            for (int i = 0; i < 7; i++)
            {
                returnWeek.Days.Add(new Day(startDayOfWeek));
                startDayOfWeek=startDayOfWeek.AddDays(1);
            }
            return returnWeek;
        }

        public DateTime GetStartDayOfWeek(DateTime week)
        {
            int delta = DayOfWeek.Monday - week.DayOfWeek;
            return week.AddDays(delta);
        }

        // This presumes that weeks start with Monday.
        // Week 1 is the 1st week of the year with a Thursday in it.
        public static int GetIso8601WeekOfYear(DateTime time)
        {
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        } 
    }

    public class Month  
    {
        public List<Week> Weeks { get; set; }

        public Month()
        {
            Weeks=new List<Week>();
        }
    }

    public class Week
    {
        public int WeekNumber { get; set; }
        public List<Day> Days { get; set; }

        public Week()
        {
            Days=new List<Day>();
        }
    }

    public class Day
    {

        public Day(DateTime day)
        {
            Date = day;
        }
        public DateTime Date { get; set; }
        public bool IsOccupied { get; set; }
    }


}