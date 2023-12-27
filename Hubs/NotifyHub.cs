using Mashrok.Domain;
using Microsoft.AspNetCore.SignalR;

namespace ProjectEweis.Hubs
{
    public class NotifyHub : Hub
    {
        public async Task NotifyAll(Notifacation model)
        {
            await Clients.All.SendAsync("NotifyAll",model);
        }

      
    }
}
