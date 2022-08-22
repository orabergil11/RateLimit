// ------------------------------------------------------------------------------------------------------- //
//                                                                                                         //
// @File      RateLimiterConfigurations.cs                                                                 //
// @Details   Global configurations for the rate limiter                                                   //
// @Author    Or Abergil                                                                                   //
// @Since     11/07/2022                                                                                   //
//                                                                                                         //
// ------------------------------------------------------------------------------------------------------- //

namespace RateLimit.Configurations
{
    public static class RateLimiterConfigurations
    {
        public const string LIMIT_EXCEEDED_MESSAGE  = "You have exceeded your call limits. Remining minutes until restriction removed is ";
        public const string INVALID_INPUT_MESSAGE   = "Invalid input";

        public static readonly TimeSpan BAN_TIME          = new TimeSpan(1, 0, 0);
        public static readonly TimeSpan CALLS_LIMIT_TIME  = new TimeSpan(0 ,1, 0);

        public const int    MAX_REQUESTS_IN_PERIOD        = 10;
        public const int    MAXֹ_USER_INPUT_LEN            = 10;
        public const int    MAX_USER_TOKEN_LEN            = 100;
    }
}
