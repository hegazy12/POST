namespace ProjectEweis.ModelView.NotificationVM
{
    public class NotificationVM
    {
        public string NotifyType { get; set; }
        public string NotifyText { get; set; }
        public string Notifyobject { get; set; }
        public string User_Id { get; set; }
        public string Post_Id { get; set; }
        public string Request_Id { get; set; }
        public List<string> ToUsers { get; set; } =new List<string>();
        public bool IsAll {get; set;} 
    }
}
