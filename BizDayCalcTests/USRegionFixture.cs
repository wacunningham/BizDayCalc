using BizDayCalc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BizDayCalcTests
{
   public class USRegionFixture
    {
        public Calculator Calc { get; private set; }

        public USRegionFixture()
        {
            Calc = new Calculator();
            Calc.AddRule(new WeekendRule());
            Calc.AddRule(new HolidayRule());
        }

        [CollectionDefinition("US region collection")]
        public class USregionCollection : ICollectionFixture<USRegionFixture>
        { }
    }
}
