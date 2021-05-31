using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Common.Utilities
{
    public static class DateTimeExtensions
    {
        public static string ToPersianDateFolderName(this DateTime value)
        {
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            var pattern = $"{pc.GetYear(value)}_{pc.GetMonth(value)}_{pc.GetDayOfMonth(value)}";
            return pattern;
        }
    }
}
