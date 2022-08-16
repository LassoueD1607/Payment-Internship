using Microsoft.AspNetCore.SignalR;

namespace PaymentInternship.Models
{
    public class UserSignalR : IUserIdProvider
    {
        public string? GetUserId(HubConnectionContext connection)
        {
            return connection.User.Identity.Name;
        }

        
    }
}
