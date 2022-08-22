// ------------------------------------------------------------------------------------------------------- //
//                                                                                                         //
// @File      Respond.cs                                                                                   //
// @Details   generic type that GoodRespond.cs and BadRespond.cs inherit, represents the poly-morphisem    //
// @Author    Or Abergil                                                                                   //
// @Since     11/07/2022                                                                                   //
//                                                                                                         //
// ------------------------------------------------------------------------------------------------------- //

namespace RateLimit.Models
{
    public abstract class Respond
    {
        public bool HasError { get; set; }
    }
}
