using System;
using System.Collections.Generic;
using System.Text;

namespace BizDayCalc
{
    public class HolidayRule:IRule
    {
        public static readonly int[,] USholidays =
        {
            {1,1}, //New Year's day
            {7,4}, // Independence day
            {12,24} , //Christmas day
            {12,25} //christmas day
        };

        public bool CheckIsBusinessDay(DateTime date)
        {
            for (int day = 0; day <= USholidays.GetUpperBound(0); day++)
            {
                if (date.Month == USholidays[day, 0] &&
                    date.Day == USholidays[day, 1])
                    return false;
            }
            return true;
        }
    }
}
