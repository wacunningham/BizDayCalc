using System;
using System.Collections.Generic;
using System.Text;

namespace BizDayCalc
{
    public interface IRule
    {
        bool CheckIsBusinessDay(DateTime date);
    }
}
