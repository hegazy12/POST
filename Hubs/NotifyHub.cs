using Mashrok.Application.IUnitOfWork;
using Mashrok.Domain;
using Mashrok.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.SignalR;

namespace ProjectEweis.Hubs
{
    public class NotifyHub : Hub
    {

        private readonly IUnitOfWork _unitOfWork;
        public NotifyHub( IUnitOfWork unitOfWork)
        {
            
            _unitOfWork = unitOfWork;
            
        }
        public async Task NotifyAll()
        {
            while (true)
            {
                Thread.Sleep(10000);
                var x = _unitOfWork.NotifacationRepo.Fitler(m => m.sent == 0);
                await Clients.All.SendAsync("NotifyAll", x);
                foreach (var item in x)
                {
                    item.sent = 1;
                }
                _unitOfWork.CommitChanges();
            }
        }
        
    }
}
