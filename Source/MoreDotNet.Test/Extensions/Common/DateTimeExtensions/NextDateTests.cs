namespace MoreDotNet.Tests.Extensions.Common.DateTimeExtensions
{
    using System;
    using System.Collections.Generic;

    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class NextDateTests
    {
        public static IEnumerable<object[]> DateTimeListWithDaysOfWeek => new[]
        {
            new object[] { new DateTime(2017, 11, 1), DayOfWeek.Monday, new DateTime(2017, 11, 6) },
            new object[] { new DateTime(2017, 11, 15), DayOfWeek.Friday, new DateTime(2017, 11, 17) },
            new object[] { new DateTime(2017, 11, 30), DayOfWeek.Saturday, new DateTime(2017, 12, 2) },
        };

        [Theory]
        [MemberData(nameof(DateTimeListWithDaysOfWeek))]
        public void NextDay_ShouldReturn_CorrectValue(DateTime currentDate, DayOfWeek dayOfWeek, DateTime expecteDateTime)
        {
            var dayOfMonthActual = currentDate.NextDate(dayOfWeek);
            Assert.Equal(expecteDateTime, dayOfMonthActual);
        }
    }
}
