namespace MoreDotNet.Tests.Extensions.Common.DateTimeExtensions
{
    using System;

    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class NoonTests
    {
        [Fact]
        public void Noon_ShouldReturn_CorrectValue()
        {
            const int iterations = 100;

            var random = new Random();
            var currentDate = new DateTime(2017, 11, 30);

            for (var i = 0; i < iterations; i++)
            {
                var randomHours = random.Next(0, 24);
                var randomMinutes = random.Next(0, 60);
                var randomSeconds = random.Next(0, 60);

                var myLocalDateTime = currentDate.AddHours(randomHours);
                myLocalDateTime = myLocalDateTime.AddMinutes(randomMinutes);
                myLocalDateTime = myLocalDateTime.AddSeconds(randomSeconds);

                var resultMidnightDate = myLocalDateTime.Noon();

                Assert.Equal(currentDate.Year, resultMidnightDate.Year);
                Assert.Equal(currentDate.Month, resultMidnightDate.Month);
                Assert.Equal(currentDate.Day, resultMidnightDate.Day);
                Assert.Equal(12, resultMidnightDate.Hour);
                Assert.Equal(currentDate.Minute, resultMidnightDate.Minute);
                Assert.Equal(currentDate.Second, resultMidnightDate.Second);
            }
        }
    }
}
