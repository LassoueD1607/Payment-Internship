using Microsoft.AspNetCore.SignalR;

namespace PaymentInternship.HubConfig
{
    public class MyHub:Hub
        
    {
        public string GetConnectionId() { cont = Context.User.Identity.Name;
            return cont; }

        public static HubCallerContext context;
        public static string cont;
        /*public async Task askServer(string someTextFromClient)
        {
            string tempString;

            if (someTextFromClient == "valid")
            {
                tempString = "Transaction done with success";
            }
            else
            {
                tempString = "Failed";
            }

            await Clients.Client(this.Context.ConnectionId).SendAsync("askServerResponse", tempString);
        }*/

    }
}
