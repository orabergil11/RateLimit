// ------------------------------------------------------------------------------------------------------- //
//                                                                                                         //
// @File      ILogicService.cs                                                                             //
// @Details   the Interface that injected to the RateLimitController                                       //
// @Author    Or Abergil                                                                                   //
// @Since     11/07/2022                                                                                   //
//                                                                                                         //
// ------------------------------------------------------------------------------------------------------- //

using RateLimit.Models;

namespace RateLimit.Services.Interfaces
{
    public interface ILogicService
    {
        public Respond GetRelevantRespond(UserInput userInput);
    }
}
