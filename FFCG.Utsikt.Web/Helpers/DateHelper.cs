using System;

namespace FFCG.Utsikt.Web.Helpers
{
    public class DateHelper
    {
        public static string GetYearIfEarlierThanThisYear(DateTime date)
        {
            return date.Year < DateTime.Now.Year ? date.Year.ToString() : string.Empty;
        }
    }
}