using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre_maritalCounSeling.Common.Util
{
    public static class GeneralValueValidateUtil
    {
        public static bool IsValidDateRange(DateTime startDate, DateTime endDate)
        {
            return startDate <= endDate;
        }   
    }
}
