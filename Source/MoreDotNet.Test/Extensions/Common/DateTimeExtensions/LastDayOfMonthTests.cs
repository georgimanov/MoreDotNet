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

        [Theory]
        [MemberData(nameof(DateTimeList))]
        public void LastDayOfMonth_ShouldReturn_CorrectValue(DateTime currentDate)
        {
            SystemTime.SetDateTime(currentDate);
            var lastDayOfMonth = new DateTime(2017, 11, 30);

            var lastDayOfMonthActual = currentDate.LastDayOfMonth();
            Assert.Equal(lastDayOfMonth, lastDayOfMonthActual);
        }
    }
}
