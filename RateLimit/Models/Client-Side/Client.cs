// ------------------------------------------------------------------------------------------------------- //
//                                                                                                         //
// @File      Client.cs                                                                                    //
// @Details   the entity that contains the relevant data about client that already reached the server      //
// @Author    Or Abergil                                                                                   //
// @Since     11/07/2022                                                                                   //
//                                                                                                         //
// ------------------------------------------------------------------------------------------------------- //

namespace RateLimit.Models
{
    public class Client
    {
        public string Token      { get; set; }
        public DateTime LastSeen { get; set; } = DateTime.Now;
        public int RequestsCounter       { get; set; } = 1;
        public bool IsBanned     { get; set; } = false;

        public Client() { }

        public Client(string token)
        {
            Token = token;
        }

        public void InitClient()
        {
            LastSeen = DateTime.Now;
            RequestsCounter = 1;
            IsBanned = false;
        }

        public void NewLegitRequest()
        {
            LastSeen = DateTime.Now;
            RequestsCounter++;
        }

        public void AnnoyingClient()
        {
            LastSeen = DateTime.Now;
            IsBanned = true;
        }
    }
}
