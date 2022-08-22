// ------------------------------------------------------------------------------------------------------- //
//                                                                                                         //
// @File      UserInput.cs                                                                                 //
// @Details   the user input and the different required restrictions                                       //
// @Author    Or Abergil                                                                                   //
// @Since     11/07/2022                                                                                   //
//                                                                                                         //
// ------------------------------------------------------------------------------------------------------- //

using RateLimit.Configurations;
using System.ComponentModel.DataAnnotations;

namespace RateLimit.Models
{
    public class UserInput
    {
        [StringLength(RateLimiterConfigurations.MAXֹ_USER_INPUT_LEN, ErrorMessage = "The number cannot exceed 10 characters. ")]
        public string? UserNumber { get; set; }

        [StringLength(RateLimiterConfigurations.MAX_USER_TOKEN_LEN, ErrorMessage = "The token input cannot exceed 100 characters. ")]
        public string? IdentifierToken { get; set; }
    }
}
