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

        //public static DateTime ToGregorian(this string ds)
        //{
        //    var pc = new sc.PersianCalendar();
        //    var dates = ds.Split("/");
        //    var resourceManager = new ResourceManagerBuilder().Build();

        //    if (dates.Length != 3)
        //        throw new ArgumentException(resourceManager.GetString(ResourceKey.InvalidPersianDateFormat));

        //    if (!int.TryParse(dates[0], out var year))
        //        throw new ArgumentException(resourceManager.GetString(ResourceKey.InvalidYear));
        //    if (!int.TryParse(dates[1], out var month))
        //        throw new ArgumentException(resourceManager.GetString(ResourceKey.InvalidMonth));
        //    if (!int.TryParse(dates[2], out var day))
        //        throw new ArgumentException(resourceManager.GetString(ResourceKey.InvalidCalendarDay));

        //    return new DateTime(year, month, day, pc);

        //}
        //public static DateTime ToGregorianWithTime(this string ds)
        //{
        //    var pc = new sc.PersianCalendar();
        //    var dates = ds.Split("/");
        //    var resourceManager = new ResourceManagerBuilder().Build();

        //    if (dates.Length != 3)
        //        throw new ArgumentException(resourceManager.GetString(ResourceKey.InvalidPersianDateFormat));

        //    if (!int.TryParse(dates[0], out var year))
        //        throw new ArgumentException(resourceManager.GetString(ResourceKey.InvalidYear));
        //    if (!int.TryParse(dates[1], out var month))
        //        throw new ArgumentException(resourceManager.GetString(ResourceKey.InvalidMonth));
        //    if (!int.TryParse(dates[2], out var day))
        //        throw new ArgumentException(resourceManager.GetString(ResourceKey.InvalidCalendarDay));

        //    return new DateTime(year, month, day, pc);
        //}
    }
}