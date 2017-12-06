namespace MoreDotNet.Extensions.Common
{
    using System;

    /// <summary>
    /// <see cref="DateTime"/> extensions.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Gets a <see cref="DateTime"/> representing the first day in the current month.
        /// </summary>
        /// <param name="date">The <see cref="DateTime"/> instance on which the extension method is called.</param>
        /// <returns>A <see cref="DateTime"/> representing the first day if the current month.</returns>
        public static DateTime FirstDayOfMonth(this DateTime date)
        {
            DateTime first = date.AddDays(1 - date.Day);
            return first;
        }

        /// <summary>
        /// Gets a DateTime representing the first specified day in the current month
        /// </summary>
        /// <param name="date">The <see cref="DateTime"/> instance on which the extension method is called.</param>
        /// <param name="dayOfWeek">The current day of week</param>
        /// <returns>A <see cref="DateTime"/> representing the first day of type <paramref name="dayOfWeek"/> of the current month.</returns>
        public static DateTime FirstDayOfMonth(this DateTime date, DayOfWeek dayOfWeek)
        {
            DateTime first = date.FirstDayOfMonth();

            if (first.DayOfWeek != dayOfWeek)
            {
                first = first.NextDate(dayOfWeek);
            }

            return first;
        }

        /// <summary>
        /// Gets a DateTime representing the last day in the current month
        /// </summary>
        /// <param name="date">The <see cref="DateTime"/> instance on which the extension method is called.</param>
        /// <returns>A <see cref="DateTime"/> representing the last day if the current month.</returns>
        public static DateTime LastDayOfMonth(this DateTime date)
        {
            int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);

            DateTime last = date.FirstDayOfMonth().AddDays(daysInMonth - 1);
            return last;
        }

        /// <summary>
        /// Gets a DateTime representing the last specified day in the current month
        /// </summary>
        /// <param name="date">The <see cref="DateTime"/> instance on which the extension method is called.</param>
        /// <param name="dayOfWeek">The current day of week</param>
        /// <returns>A <see cref="DateTime"/> representing the last day of type <paramref name="dayOfWeek"/> of the current month.</returns>
        public static DateTime LastDayOfMonth(this DateTime date, DayOfWeek dayOfWeek)
        {
            var lastDayOfMonth = date.LastDayOfMonth();
            var theWeekBefore = lastDayOfMonth.AddDays(-7);

            return theWeekBefore.NextDate(dayOfWeek);
        }

        /// <summary>
        /// Gets a <see cref="DateTime"/> representing the first date following the current date which falls on the given day of the week.
        /// </summary>
        /// <param name="date">The <see cref="DateTime"/> instance on which the extension method is called.</param>
        /// <param name="dayOfWeek">The day of week for the next date to get</param>
        /// <returns>A <see cref="DateTime"/> representing the first date following the current date which falls on the given day of the week.</returns>
        public static DateTime NextDate(this DateTime date, DayOfWeek dayOfWeek)
        {
            int offsetDays = dayOfWeek - date.DayOfWeek;

            if (offsetDays <= 0)
            {
                offsetDays += 7;
            }

            DateTime result = date.AddDays(offsetDays);
            return result;
        }

        /// <summary>
        /// Gets a <see cref="DateTime"/> representing midnight on the current date.
        /// </summary>
        /// <param name="date">The <see cref="DateTime"/> instance on which the extension method is called.</param>
        /// <returns>A <see cref="DateTime"/> representing midnight on the current date.</returns>
        public static DateTime Midnight(this DateTime date)
        {
            DateTime midnight = new DateTime(date.Year, date.Month, date.Day);
            return midnight;
        }

        /// <summary>
        /// Gets a <see cref="DateTime"/> representing noon on the current date.
        /// </summary>
        /// <param name="date">The <see cref="DateTime"/> instance on which the extension method is called.</param>
        /// <returns>A <see cref="DateTime"/> representing noon on the current date.</returns>
        public static DateTime Noon(this DateTime date)
        {
            DateTime noon = new DateTime(date.Year, date.Month, date.Day, 12, 0, 0);
            return noon;
        }

        /// <summary>
        /// Sets the time of the current date with millisecond precision.
        /// </summary>
        /// <param name="date">The <see cref="DateTime"/> instance on which the extension method is called.</param>
        /// <param name="hour">The hour</param>
        /// <param name="minute">The minute</param>
        /// <param name="second">The second</param>
        /// <param name="millisecond">The millisecond</param>
        /// <returns>The new <see cref="DateTime"/> instance.</returns>
        public static DateTime WithTime(this DateTime date, int hour, int minute, int second = 0, int millisecond = 0)
        {
            DateTime newTime = new DateTime(date.Year, date.Month, date.Day, hour, minute, second, millisecond);
            return newTime;
        }

        /// <summary>
        /// Check if the <see cref="DateTime"/> instance represents a future time in comparison to <paramref name="from"/>.
        /// </summary>
        /// <param name="date">The <see cref="DateTime"/> instance on which the extension method is called.</param>
        /// <param name="from">A reference point, form witch we check if the current date is in the future.</param>
        /// <returns>True if the date is in the future. False otherwise.</returns>
        public static bool IsFuture(this DateTime date, DateTime from)
        {
            return date.Ticks > from.Ticks;
        }

        /// <summary>
        /// Check if the <see cref="DateTime"/> instance represents a future date in comparison to <paramref name="from"/>.
        /// </summary>
        /// <param name="date">The <see cref="DateTime"/> instance on which the extension method is called.</param>
        /// <param name="from">A reference point, form witch we check if the current date is in the future.</param>
        /// <returns>True if the date is in the future. False otherwise.</returns>
        public static bool IsFutureDate(this DateTime date, DateTime from)
        {
            return date.Date > from.Date;
        }

        /// <summary>
        /// Check if the <see cref="DateTime"/> instance represents a future date.
        /// </summary>
        /// <param name="date">The <see cref="DateTime"/> instance on which the extension method is called.</param>
        /// <returns>True if the date is in the future. False otherwise.</returns>
        public static bool IsFuture(this DateTime date)
        {
            return date.IsFuture(DateTime.Now);
        }

        public static bool IsPast(this DateTime date, DateTime from)
        {
            return date.Date < from.Date;
        }

        /// <summary>
        /// Check if the <see cref="DateTime"/> instance represents a past date.
        /// </summary>
        /// <param name="date">The <see cref="DateTime"/> instance on which the extension method is called.</param>
        /// <returns>True if the date is in the past. False otherwise.</returns>
        public static bool IsPast(this DateTime date)
        {
            return date.IsPast(DateTime.Now);
        }

        /// <summary>
        /// Check if the <see cref="DateTime"/> instance is a work day.
        /// </summary>
        /// <param name="date">The <see cref="DateTime"/> instance on which the extension method is called.</param>
        /// <returns>True if the <see cref="DateTime"/> instance is a work day. False otherwise.</returns>
        public static bool IsWorkDay(this DateTime date)
        {
            return date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday;
        }

        /// <summary>
        /// Check if the <see cref="DateTime"/> instance is a weekend day.
        /// </summary>
        /// <param name="date">The <see cref="DateTime"/> instance on which the extension method is called.</param>
        /// <returns>True if the <see cref="DateTime"/> instance is a weekend day. False otherwise.</returns>
        public static bool IsWeekend(this DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }

        /// <summary>
        /// Gets the next work day.
        /// </summary>
        /// <param name="date">The <see cref="DateTime"/> instance on which the extension method is called.</param>
        /// <returns>The next work day.</returns>
        public static DateTime NextWorkday(this DateTime date)
        {
            var nextDay = date;
            while (!nextDay.IsWorkDay())
            {
                nextDay = nextDay.AddDays(1);
            }

            return nextDay;
        }
    }
}
