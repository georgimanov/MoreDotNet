namespace MoreDotNet.Tests.Extensions.Common.DateTimeExtensions
{
    using System;
    using System.Collections.Generic;

    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class LastDayOfMonthTests
    {
        public static IEnumerable<object[]> DateTimeList => new[]
        {
            new object[] { new DateTime(2017, 11, 1) },
            new object[] { new DateTime(2017, 11, 15) },
            new object[] { new DateTime(2017, 11, 30) },
        };

        public static IEnumerable<object[]> DateTimeListWithDaysOfWeek => new[]
        {
            new object[] { new DateTime(2017, 11, 1), DayOfWeek.Monday, new DateTime(2017, 11, 27) },
            new object[] { new DateTime(2017, 11, 15), DayOfWeek.Friday, new DateTime(2017, 11, 24) },
            new object[] { new DateTime(2017, 11, 30), DayOfWeek.Saturday, new DateTime(2017, 11, 25) },
            new object[] { new DateTime(2017, 11, 30), DayOfWeek.Thursday, new DateTime(2017, 11, 30) }
        };

        [Theory]
        [MemberData(nameof(DateTimeList))]
        public void LastDayOfMonth_ShouldReturn_CorrectValue(DateTime currentDate)
        {
            var lastDayOfMonth = new DateTime(2017, 11, 30);

            var lastDayOfMonthActual = currentDate.LastDayOfMonth();
            Assert.Equal(lastDayOfMonth, lastDayOfMonthActual);
        }

        [Theory]
        [MemberData(nameof(DateTimeListWithDaysOfWeek))]
        public void LastDayOfMonthWithSpecifiedDayOfWeek_ShouldReturn_CorrectValue(DateTime currentDate, DayOfWeek dayOfWeek, DateTime lastDayOfMonthExpected)
        {
            var lastDayOfMonthActual = currentDate.LastDayOfMonth(dayOfWeek);
            Assert.Equal(lastDayOfMonthExpected, lastDayOfMonthActual);
        }
    }
}
