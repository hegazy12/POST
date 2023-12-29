using ProjectEweis.ModelView.NotificationVM;

namespace ProjectEweis.Services.Notification
{
    public interface INotification
    {
        public NotificationVM MakeNotification();
        public NotificationVM NtfyAddCommercial(string IDPOST);
        public NotificationVM NtfyAddreal_estate_yes(string IDPOST);
        public NotificationVM NtfyAddreal_estate_no(string IDPOST);
        public NotificationVM NtfyAddRequest_Commercial(string IDPOST);
        public NotificationVM NtfyAddRequest_Real_Estate_Yes(string IDPOST);
        public NotificationVM NtfyAddRequest_Real_Estate_No(string IDPOST);

    }
}
