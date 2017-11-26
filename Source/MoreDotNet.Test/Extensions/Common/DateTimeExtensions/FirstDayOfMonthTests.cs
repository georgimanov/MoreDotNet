namespace MoreDotNet.Tests.Extensions.Common.DateTimeExtensions
{
    using System;
    using System.Collections.Generic;

    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class FirstDayOfMonthTests
    {
        public static IEnumerable<object[]> DateTimeList => new[]
        {
            new object[] { new DateTime(2017, 11, 1) },
            new object[] { new DateTime(2017, 11, 15) },
            new object[] { new DateTime(2017, 11, 30) },
        };

        public static IEnumerable<object[]> DateTimeListWithDaysOfWeek => new[]
        {
            new object[] { new DateTime(2017, 11, 1), DayOfWeek.Monday, new DateTime(2017, 11, 6) },
            new object[] { new DateTime(2017, 11, 15), DayOfWeek.Friday, new DateTime(2017, 11, 3) },
            new object[] { new DateTime(2017, 11, 30), DayOfWeek.Saturday, new DateTime(2017, 11, 4) },
        };

        [Theory]
        [MemberData(nameof(DateTimeList))]
        public void FirstDayOfMonth_ShouldReturn_CorrectValue(DateTime currentDate)
        {
            SystemTime.SetDateTime(currentDate);
            var firstDayOfMonthExpected = new DateTime(2017, 11, 1);

            var firstDayOfMonthActual = currentDate.FirstDayOfMonth();
            Assert.Equal(firstDayOfMonthExpected, firstDayOfMonthActual);
        }

        [Theory]
        [MemberData(nameof(DateTimeListWithDaysOfWeek))]
        public void FirstDayOfMonthWithSpecifiedDayOfWeek_ShouldReturn_CorrectValue(DateTime currentDate, DayOfWeek dayOfWeek, DateTime firstDayOfMonthExpected)
        {
            SystemTime.SetDateTime(currentDate);
            var firstDayOfMonthActual = currentDate.FirstDayOfMonth(dayOfWeek);
            Assert.Equal(firstDayOfMonthExpected, firstDayOfMonthActual);
        }
    }
}
