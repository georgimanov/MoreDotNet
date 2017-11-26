namespace MoreDotNet.Tests.Extensions.Common.DateTimeExtensions
{
    using System;

    /// <summary>
    /// Used for getting DateTime.Now(), time is changeable for unit testing
    /// </summary>
    public static class SystemTime
    {
        /// <summary>
        /// Normally this is a pass-through to DateTime.Now, but it can be overridden with SetDateTime( .. ) for testing or debugging.
        /// </summary>
        private static Func<DateTime> _now = () => DateTime.Now;

        /// <summary>
        /// Set time to return when SystemTime.Now() is called.
        /// </summary>
        /// <param name="dateTimeNow">The time to set.</param>
        public static void SetDateTime(DateTime dateTimeNow)
        {
            _now = () => dateTimeNow;
        }

        /// <summary>
        /// Resets SystemTime.Now() to return DateTime.Now.
        /// </summary>
        public static void ResetDateTime()
        {
            _now = () => DateTime.Now;
        }
    }
}
