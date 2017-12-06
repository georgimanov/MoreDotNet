using Xunit.Sdk;

namespace MoreDotNet.Tests.Extensions.Common.DateTimeExtensions
{
    using System;
    using MoreDotNet.Extensions.Common;
    using Xunit;

    public class IsFutureTests
    {
        [Fact]
        public void IsFuture_ShouldReturn_False()
        {
            var checkDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day - 1);

            Assert.False(checkDateTime.IsFuture());
        }

        [Fact]
        public void IsFuture_ShouldReturn_True()
        {
            var checkDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1);

            Assert.True(checkDateTime.IsFuture());
        }

        [Fact(Skip = "Needs further investigation")]
        public void IsFuture_ShouldReturn_True_ForDateTimeNowPlusOneHour_Local()
        {
            var now = DateTime.Now;
            var checkDateTime = new DateTime(now.Year, now.Month, now.Day, now.Hour + 1, now.Minute, now.Second, DateTimeKind.Local);

            Assert.Equal(now.Kind, checkDateTime.Kind);
            Assert.True(checkDateTime.IsFuture());
        }

        [Fact]
        public void IsFuture_ShouldReturn_False_ForDateTimeNowPlusOneHour_Utc()
        {
            var now = DateTime.Now;
            var checkDateTime = new DateTime(now.Year, now.Month, now.Day, now.Hour + 1, now.Minute, now.Second, DateTimeKind.Utc);

            Assert.NotEqual(now.Kind, checkDateTime.Kind);
            Assert.False(checkDateTime.IsFuture());
        }

        [Fact]
        public void IsFuture_ShouldReturn_False_ForDateTimeNowPlusOneHour_Unspecified()
        {
            var now = DateTime.Now;
            var checkDateTime = new DateTime(now.Year, now.Month, now.Day, now.Hour + 1, now.Minute, now.Second, DateTimeKind.Unspecified);

            Assert.NotEqual(now.Kind, checkDateTime.Kind);
            Assert.False(checkDateTime.IsFuture());
        }

        [Fact]
        public void IsFuture_ShouldReturn_Fasle_ForDateTimeNow()
        {
            Assert.False(DateTime.Now.IsFuture());
        }
    }
}
