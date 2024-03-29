﻿
using Mashrok.Application.IUnitOfWork;
using Mashrok.Domain;
using Microsoft.AspNetCore.SignalR;

using ServiceStack;

namespace ProjectEweis.Hubs
{
    public class ChatHub:Hub
    {
       
         private readonly IUnitOfWork _unitOfWork;
        public ChatHub(IUnitOfWork unitOfWork)
        {
            
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
        
        //public async Task NotifyAll()
        //{
        //    List<Notifacation> x;
        //    while (true)
        //    {  
        //        x = (List<Notifacation>)_unitOfWork.NotifacationRepo.Fitler(m => m.sent == 0);
        //        if (x.Count != 0)
        //        {
        //            await Clients.All.SendAsync("NotifyAll", x);
        //            Thread.Sleep(1000);
        //            foreach (var item in x)
        //            {
        //                item.sent = 1;
        //                _unitOfWork.CommitChanges();
        //            }
        //            x = new List<Notifacation>();
        //        }
        //    }
        //}
    }
}
