// ------------------------------------------------------------------------------------------------------- //
//                                                                                                         //
// @File      LogicService.cs                                                                              //
// @Details   Responsible on different logical methods and the layer the connects between controller to db //
// @Author    Or Abergil                                                                                   //
// @Since     11/07/2022                                                                                   //
//                                                                                                         //
// ------------------------------------------------------------------------------------------------------- //

using RateLimit.Configurations;
using RateLimit.Models;
using RateLimit.Services.Interfaces;

namespace RateLimit.Services
{
    public class LogicService : ILogicService
    {
        IRateLimiterService _rateLimiterService;

        public LogicService(IRateLimiterService rateLimiterService)
        {
            _rateLimiterService = rateLimiterService;
        }

        public Respond GetRelevantRespond(UserInput userInput)
        {
            Respond resp;

            //users rate limit check
            if (!_rateLimiterService.IsRateLimitLegit(userInput.IdentifierToken, out TimeSpan timeRemainUntilLegit))
            {
                resp = new BadRespond { HasError = true, ErrorMessage = RateLimiterConfigurations.LIMIT_EXCEEDED_MESSAGE + timeRemainUntilLegit.ToString(@"hh\:mm\:ss") + " Minutes" };
            }
            else
            {
                if (int.TryParse(userInput.UserNumber, out int userNum))
                {
                    if (IsPrime(userNum))
                    {
                        resp = new GoodRespond { HasError = false, Number = userNum, IsPrime = true };
                    }

                    else
                    {
                        resp = new GoodRespond { HasError = false, Number = userNum, IsPrime = false };
                    }
                }
                else
                {
                    resp = new BadRespond { HasError = true, ErrorMessage = RateLimiterConfigurations.INVALID_INPUT_MESSAGE };
                }
            }
            return resp;
        }
        
        private bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }
    }
}
