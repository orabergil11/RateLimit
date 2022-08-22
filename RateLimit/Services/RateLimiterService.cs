// ------------------------------------------------------------------------------------------------------- //
//                                                                                                         //
// @File      RateLimiterService.cs                                                                        //
// @Details   Responsible to enforce the rate limiter rules                                                //
// @Author    Or Abergil                                                                                   //
// @Since     11/07/2022                                                                                   //
//                                                                                                         //
// ------------------------------------------------------------------------------------------------------- //

using RateLimit.Services.Interfaces;
using RateLimit.Configurations;
using RateLimit.Models;

namespace RateLimit.Repo
{
    public class RateLimiterService : IRateLimiterService
    {
        // collection of all clients that reached the server so far
        public Dictionary<string, Client> Clients { get; set; }

        public RateLimiterService()
        {
            Clients = new Dictionary<string, Client>();
        }

        public bool IsRateLimitLegit(string userToken, out TimeSpan timeRemainUntilBanFinished)
        {
            timeRemainUntilBanFinished = default;

            // unknown client
            if (!Clients.ContainsKey(userToken))
            {
                Client newClient = new Client(userToken);
                Clients.Add(userToken, newClient);
                return true;
            }

            // known client 
            Client client = new Client();
            Clients.TryGetValue(userToken, out client);

            if (client.IsBanned)
            {
                TimeSpan timeGap = DateTime.Now.Subtract(client.LastSeen);

                // check if ban time passed
                if (timeGap >= RateLimiterConfigurations.BAN_TIME)
                {
                    client.InitClient();
                    return true;
                }

                // stilled banned ,ignore the client
                else
                {
                    timeRemainUntilBanFinished = timeGap - RateLimiterConfigurations.BAN_TIME;
                    return false;
                }
            }

            // legit user with old last seen
            if (DateTime.Now.Subtract(client.LastSeen) > RateLimiterConfigurations.CALLS_LIMIT_TIME)
            {
                client.InitClient();
                return true;
            }

            // user reached too much requests in the time period,ban him
            if (client.RequestsCounter == RateLimiterConfigurations.MAX_REQUESTS_IN_PERIOD)
            {
                client.AnnoyingClient();
                return false;
            }

            client.NewLegitRequest();
            return true;
        }
    }
}
