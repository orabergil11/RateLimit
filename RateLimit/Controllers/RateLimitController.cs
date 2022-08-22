// ------------------------------------------------------------------------------------------------------- //
//                                                                                                         //
// @File      RateLimitController.cs                                                                       //
// @Details   holds the different API's Operations and handle different client requests                    //
// @Author    Or Abergil                                                                                   //
// @Since     11/07/2022                                                                                   //
//                                                                                                         //
// ------------------------------------------------------------------------------------------------------- //

using RateLimit.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RateLimit.Models;

namespace RateLimit.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RateLimitController : ControllerBase
    {
        private readonly ILogicService _logicService;

        public RateLimitController(ILogicService logicService)
        {
            _logicService = logicService;
        }

        [HttpPost]
        public Respond IsPrimeNumber(UserInput userInput)
        {
            return _logicService.GetRelevantRespond(userInput);
        }
    }
}