namespace MoreDotNet.Tests.Extensions.Common.DateTimeExtensions
{
    using System;

    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class WithTimeTests
    {
        [Fact]
        public void WithTimeTests_ShouldReturn_CorrectValue()
        {
            const int iterations = 100;
            const int year = 2017;
            const int month = 11;
            const int day = 30;

            var random = new Random();
            for (var i = 0; i < iterations; i++)
            {
                var randomHours = random.Next(0, 24);
                var randomMinutes = random.Next(0, 60);
                var randomSeconds = random.Next(0, 60);
                var randomMilliSeconds = random.Next(0, 1000);

                var currentDate = new DateTime(year, month, day);
                Assert.Equal(currentDate.Year, year);
                Assert.Equal(currentDate.Month, month);
                Assert.Equal(currentDate.Day, day);
                Assert.Equal(currentDate.Hour, 0);
                Assert.Equal(currentDate.Minute, 0);
                Assert.Equal(currentDate.Second, 0);
                Assert.Equal(currentDate.Millisecond, 0);

                var resultMidnightDate = currentDate.WithTime(randomHours, randomMinutes, randomSeconds, randomMilliSeconds);
                Assert.Equal(year, resultMidnightDate.Year);
                Assert.Equal(month, resultMidnightDate.Month);
                Assert.Equal(day, resultMidnightDate.Day);
                Assert.Equal(randomHours, resultMidnightDate.Hour);
                Assert.Equal(randomMinutes, resultMidnightDate.Minute);
                Assert.Equal(randomSeconds, resultMidnightDate.Second);
                Assert.Equal(randomMilliSeconds, resultMidnightDate.Millisecond);
            }
        }
    }
}
