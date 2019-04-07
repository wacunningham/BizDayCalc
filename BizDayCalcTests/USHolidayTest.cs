using System;
using Xunit;
using BizDayCalc;
using System.Collections.Generic;


namespace BizDayCalcTests
{
    public class USHolidayTest
    {
        public static IEnumerable<object []> Holidays
        {
            get
            {
                yield return new object[] { new DateTime(2016, 1, 1) };
                yield return new object[] { new DateTime(2016, 7, 4) };
                yield return new object[] { new DateTime(2016, 12, 24) };
                yield return new object[] { new DateTime(2016, 12, 25) };
            }
        }

     public static IEnumerable<object[]> NonHolidays
        {
            get
            {
                yield return new object[] { new DateTime(2016, 12, 1) };
                yield return new object[] { new DateTime(2016, 12, 1) };
            }
        }

        private Calculator calculator;
        
        public USHolidayTest()
        {
            calculator = new Calculator();
            calculator.AddRule(new HolidayRule());
            Console.WriteLine("In USholidayTest constructor");
        }

        [Theory]
        [MemberData(nameof(Holidays))]
        public void TestHoliday(string date)
        {
            Assert.False(calculator.IsBusinessDay(DateTime.Parse(date)));
            Console.WriteLine($"In TestHolidays {date}");
        }

        [Theory]
        [MemberData(nameof(NonHolidays))]
        public void TestNonHoliday(string date)
        {
            Assert.True(calculator.IsBusinessDay(DateTime.Parse(date)));
            Console.WriteLine($"In TestNonHolidays {date:yyyy-MM-dd}");
        }

    }
}
