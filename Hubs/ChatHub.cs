
using Mashrok.Application.IUnitOfWork;
using Mashrok.Domain;
using Microsoft.AspNetCore.SignalR;

using ServiceStack;

namespace ProjectEweis.Hubs
{
    public class ChatHub:Hub
    {
        // private readonly ApplicationDbContext _db;
         private readonly IUnitOfWork _unitOfWork;
        public ChatHub(/*ApplicationDbContext d*/IUnitOfWork unitOfWork)
        {
            //_db = db;
            _unitOfWork = unitOfWork;
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


        //public async Task NotifyAll(string hh)
        //{
        //    await Clients.All.SendAsync("NotifyAll",hh);
        //}

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
          _unitOfWork.MessageRepo.Insert(message1);
            _unitOfWork.CommitChanges();
            return Clients.Group(receiver).SendAsync("ReceiveMessage",sender, message);
        }

        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }
    }
}
