using System;
using Xunit;
using BizDayCalc;
using System.Collections.Generic;

namespace BizDayCalcTests
{
    public class WeekendRuleTest
    {
        [Fact]
        public void Test1()
        {
            var rule = new WeekendRule();
            Assert.True(rule.CheckIsBusinessDay(new DateTime(2016, 6, 27)));
            Assert.False(rule.CheckIsBusinessDay(new DateTime(2016, 6, 26)));
        }

        [Theory]
        [InlineData("2016-06-27")] // Monday
        [InlineData("2016-03-01")] // Tuesday
        [InlineData("2017-09-20")] //Wednesday
        public void IsBuisnessday(string date)
        {
            var rule = new WeekendRule();
            Assert.True(rule.CheckIsBusinessDay(DateTime.Parse(date)));
        }

        [Theory]
        [InlineData("2017-09-16")] //Sunday
        [InlineData("2017-09-17")] //Sunday
        public void IsNotBusinessDay(string date)
        {
            var rule = new WeekendRule();
            Assert.False(rule.CheckIsBusinessDay(DateTime.Parse(date)));
        }

        public static IEnumerable<object[]> Days
        {
            get
            {
                yield return new object[] { true, new DateTime(2016, 6, 27) };
            }
        }
    }
}
