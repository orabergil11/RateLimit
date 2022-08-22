// ------------------------------------------------------------------------------------------------------- //
//                                                                                                         //
// @File      GoodRespond.cs                                                                               //
// @Details   the props that shows up as json if the user enter valid values                               //
// @Author    Or Abergil                                                                                   //
// @Since     11/07/2022                                                                                   //
//                                                                                                         //
// ------------------------------------------------------------------------------------------------------- //

namespace RateLimit.Models
{
    public class GoodRespond : Respond
    {
        public int? Number { get; set; }
        public bool IsPrime { get; set; }
    }
}
