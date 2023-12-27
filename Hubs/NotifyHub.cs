using Mashrok.Domain;
using Microsoft.AspNetCore.SignalR;

namespace ProjectEweis.Hubs
{
    public class NotifyHub : Hub
    {
        public async Task NotifyAll(string hh)
        {
            await Clients.All.SendAsync("NotifyAll",hh);
        }

      
    }
}
