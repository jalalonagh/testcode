using Common.Resource;
using System;
using sc = System.Globalization;

namespace Common.Utilities
{
    public static class PersianCalendar
    {
        public static string ToPersian(this DateTime dt)
        {
            var pc = new sc.PersianCalendar();
            return $"{pc.GetYear(dt).ToString("0000")}/{pc.GetMonth(dt).ToString("00")}/{pc.GetDayOfMonth(dt).ToString("00")}";
        }

        public static string ToPersianWithTime(this DateTime dt)
        {
            var pc = new sc.PersianCalendar();
            return $"{pc.GetYear(dt)}/{pc.GetMonth(dt)}/{pc.GetDayOfMonth(dt)} {dt.Hour}:{dt.Minute}:{dt.Second}";
        }
    }
}