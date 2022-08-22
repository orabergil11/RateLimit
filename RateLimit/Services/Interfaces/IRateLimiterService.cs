// ------------------------------------------------------------------------------------------------------- //
//                                                                                                         //
// @File      IRateLimiterService.cs                                                                       //
// @Details   the Interface that injected to the logic layer                                               //
// @Author    Or Abergil                                                                                   //
// @Since     11/07/2022                                                                                   //
//                                                                                                         //
// ------------------------------------------------------------------------------------------------------- //

using RateLimit.Models;

namespace RateLimit.Services.Interfaces
{
    public interface IRateLimiterService
    {
        Dictionary<string, Client> Clients { get; set; }
        public bool IsRateLimitLegit(string userToken, out TimeSpan timeRemainUntilLegit);
    }
}
