using DAL.DBContext;
using Microsoft.AspNetCore.SignalR;
using ProjectEweis.Models;
using ServiceStack;

namespace ProjectEweis.Hubs
{
    public class ChatHub:Hub
    {
        private readonly ApplicationDbContext _db;
        public ChatHub(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task SendMessage(string user ,string message)
        {
            await Clients.All.SendAsync("ReceiveMessage",user, message);
        }

        public async Task SendToUser(string user, string receiverConnectionId, string message)
        {
            await Clients.Client(receiverConnectionId).SendAsync("ReceiveMessage", user, message);
        }
        public  Task GetUser(string userId)
        {
           return Groups.AddToGroupAsync(Context.ConnectionId,userId);
        }

        public Task SendMessageToGroup(string receiver,string sender, string message,string requestId)
        {
            Message message1 = new Message
            {
                ReceiverId = receiver,
                SenderId = sender,
                RequestId = requestId,
                Text = message,
                When = DateTime.Now,
                Deleted = false
            };
            _db.Messages.Add(message1);
            _db.SaveChanges();
            return Clients.Group(receiver).SendAsync("ReceiveMessage",sender, message);
        }

        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }
    }
}
