using Mashrok.Application.IUnitOfWork;
using Mashrok.Domain;
using Nancy.Json;
using Newtonsoft.Json;
using NuGet.Protocol;
using ProjectEweis.ModelView.NotificationVM;


namespace ProjectEweis.Services.Notification
{
    public class Notification : INotification
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public Notification(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; 
        }

        public NotificationVM MakeNotification()
        {
            throw new NotImplementedException();
        }

        public NotificationVM NtfyAddreal_estate_yes(string IDPOST) 
        {
            NotificationVM notification = new NotificationVM() { NotifyText = "We Add a New POST in Addreal_estate_yes" };
            Notifacation notification1 = new Notifacation
            {
                NotifyText = notification.NotifyText,
                Notifyobject = notification.Notifyobject,
                NotifyType = notification.NotifyType,
                Post_Id = notification.Post_Id,
                Request_Id = notification.Request_Id,
                Usr_Id = notification.User_Id,
                sent = 0
            };
            notification.Post_Id = IDPOST;
            
            var POST = _unitOfWork.         
                        real_estate_yesRepo.
                        Fitler(m => m.ID.ToString() == IDPOST).
                        FirstOrDefault();
                                         
            notification.Notifyobject = POST.ToJson();
            notification.IsAll = true;
            _unitOfWork.NotifacationRepo.Insert(notification1);
            _unitOfWork.CommitChanges();
            return notification;
        }

        public NotificationVM NtfyAddCommercial(string IDPOST)
        {
            NotificationVM notification = new NotificationVM() { NotifyText = "We Add a New POST in Commercial" };
            Notifacation notification1 = new Notifacation
            {
                NotifyText = notification.NotifyText,
                Notifyobject = notification.Notifyobject,
                NotifyType = notification.NotifyType,
                Post_Id = notification.Post_Id,
                Request_Id = notification.Request_Id,
                Usr_Id = notification.User_Id,
                sent = 0
            };
            notification.Post_Id = IDPOST;
            
            var POST = _unitOfWork.
                        commercialRepo.
                        Fitler(m => m.ID.ToString() == IDPOST).
                        FirstOrDefault();

             notification.Notifyobject = JsonConvert.SerializeObject(POST);
            notification.IsAll = true;
            _unitOfWork.NotifacationRepo.Insert(notification1);
            _unitOfWork.CommitChanges();
            return notification;
        }

        public NotificationVM NtfyAddreal_estate_no(string IDPOST)
        {
            NotificationVM notification = new NotificationVM() { NotifyText = "We Add a New POST in Addreal_estate_no" };
            Notifacation notification1 = new Notifacation
            {
                NotifyText = notification.NotifyText,
                Notifyobject = notification.Notifyobject,
                NotifyType = notification.NotifyType,
                Post_Id = notification.Post_Id,
                Request_Id = notification.Request_Id,
                Usr_Id = notification.User_Id,
                sent = 0
            };
            notification.Post_Id = IDPOST;

            var POST = _unitOfWork.
                        real_estate_noRepo.
                        Fitler(m => m.ID.ToString() == IDPOST).
                        FirstOrDefault();

            notification.Notifyobject = JsonConvert.SerializeObject(POST);

            notification.IsAll = true;
            _unitOfWork.NotifacationRepo.Insert(notification1);
            _unitOfWork.CommitChanges();
            return notification;
        }

        public NotificationVM NtfyAddRequest_Commercial(string IDPOST)
        {
            NotificationVM notification =  new NotificationVM() { NotifyText = "We Add a New POST in Request_Commercial" };
            Notifacation notification1 = new Notifacation
            {
                NotifyText = notification.NotifyText,
                Notifyobject = notification.Notifyobject,
                NotifyType = notification.NotifyType,
                Post_Id = notification.Post_Id,
                Request_Id = notification.Request_Id,
                Usr_Id = notification.User_Id,
                sent = 0
            };
            var POST = _unitOfWork.
                        commercialRepo.
                        Fitler(m => m.ID.ToString() == IDPOST).
                        FirstOrDefault();

            notification.ToUsers.Add(POST.Owner.Id);
            
            notification.ToUsers.AddRange (_unitOfWork.UserRequestRepo.
                Fitler(m => m.commercial.ID.ToString() == IDPOST)
                .Select(m => m.Requester.Id).ToList());

            notification.IsAll = false;

            notification.Notifyobject = JsonConvert.SerializeObject(POST);
            _unitOfWork.NotifacationRepo.Insert(notification1);
            _unitOfWork.CommitChanges();
            return notification;
        }

        public NotificationVM NtfyAddRequest_Real_Estate_No(string IDPOST)
        {
            NotificationVM notification = new NotificationVM() { NotifyText = "We Add a New POST in Request_Real_Estate_No" };
            Notifacation notification1 = new Notifacation
            {
                NotifyText = notification.NotifyText,
                Notifyobject = notification.Notifyobject,
                NotifyType = notification.NotifyType,
                Post_Id = notification.Post_Id,
                Request_Id = notification.Request_Id,
                Usr_Id = notification.User_Id,
                sent = 0
            };
            var POST = _unitOfWork.
                        commercialRepo.
                        Fitler(m => m.ID.ToString() == IDPOST).
                        FirstOrDefault();

            notification.ToUsers.Add(POST.Owner.Id);

           

            notification.ToUsers.AddRange(_unitOfWork.UserRequestRepo.
                Fitler(m => m.real_estate_no.ID.ToString() == IDPOST)
                .Select(m => m.Requester.Id).ToList());

            notification.Post_Id = IDPOST;

            notification.IsAll = false;
            _unitOfWork.NotifacationRepo.Insert(notification1);
            _unitOfWork.CommitChanges();

            return notification;
        }

        public NotificationVM NtfyAddRequest_Real_Estate_Yes(string IDPOST)
        {
            NotificationVM notification = new NotificationVM() { NotifyText = "We Add a New POST in Request_Real_Estate_Yes" };
            Notifacation notification1 = new Notifacation
            {
                NotifyText = notification.NotifyText,
                Notifyobject = notification.Notifyobject,
                NotifyType = notification.NotifyType,
                Post_Id = notification.Post_Id,
                Request_Id = notification.Request_Id,
                Usr_Id = notification.User_Id,
                sent = 0
            };
            var POST = _unitOfWork.
                        commercialRepo.
                        Fitler(m => m.ID.ToString() == IDPOST).
                        FirstOrDefault();

            notification.ToUsers.Add(POST.Owner.Id);

            notification.ToUsers.AddRange(_unitOfWork.UserRequestRepo.
                Fitler(m => m.real_estate_no.ID.ToString() == IDPOST)
                .Select(m => m.Requester.Id).ToList());

            notification.Post_Id = IDPOST;

            notification.IsAll = false;
            _unitOfWork.NotifacationRepo.Insert(notification1);
            _unitOfWork.CommitChanges();
            return notification;
        }
    }
}
