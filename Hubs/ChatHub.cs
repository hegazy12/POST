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
        public  Task GetUser(string recever)
        {
            //var grbName = recever += sender;
            return Groups.AddToGroupAsync(Context.ConnectionId, recever);
        }

        public Task SendMessageToGroup(string receiverId,string senderId, string message,string requestId)
        {
            Message message1 = new Message
            {
                ReceiverId = receiverId,
                SenderId = senderId,
                RequestId = requestId,
                Text = message,
                When = DateTime.Now,
                Deleted = false
            };
            _db.Messages.Add(message1);
            _db.SaveChanges();
          //  var grbName = receiverId += senderId;

            return Clients.Group(receiverId).SendAsync("ReceiveMessage", senderId, message);
        }

        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }
    }
}
