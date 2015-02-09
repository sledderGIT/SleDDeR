using System;

namespace Investor.Core
{
    public static class UnixTimeStampExtension
    {
        public static int TimeStamp(this DateTime date)
        {
            return (int)(date.Subtract (new DateTime (1970, 1, 1))).TotalSeconds;
        }
    }
}