// ------------------------------------------------------------------------------------------------------- //
//                                                                                                         //
// @File      BadRespond.cs                                                                                //
// @Details   the prop that shows up if the user didnt entered valid value                                 //
// @Author    Or Abergil                                                                                   //
// @Since     11/07/2022                                                                                   //
//                                                                                                         //
// ------------------------------------------------------------------------------------------------------- //

namespace RateLimit.Models
{
    public class BadRespond : Respond
    {
        public string? ErrorMessage { get; set; }
    }
}
