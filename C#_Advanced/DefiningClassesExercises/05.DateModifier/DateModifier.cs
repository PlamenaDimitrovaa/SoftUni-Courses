using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifier
{
    public static class DateModifier
    {
        public static int CalculateDifferenceInDays(string firstDate, string secondDate)
        {
            DateTime dateOne = DateTime.Parse(firstDate);
            DateTime dateTwo = DateTime.Parse(secondDate);
            int days = (dateOne - dateTwo).Days;
            return days;
        }
    }
}
