using System.Net;
using System.Net.Mail;

namespace ProjectEweis.Services
{
    public class MailService
    {
        MailAddress mailAddress;
        public MailService(MailAddress _mailAddress)
        {
            mailAddress = _mailAddress;
        }
        public async Task<MailMessage> SendMail(string url, string subject)
        {


            using (MailMessage message = new MailMessage())
            {
                message.From = new MailAddress("ahmeddev9705@gmail.com");
                message.To.Add(mailAddress);
                message.Subject = subject;
                message.IsBodyHtml = true; //to make message body as html  

                message.Body = url;


                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {

                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("ahmeddev9705@gmail.com", "tclqrrryyoeasbay");
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Send(message);
                }

                return message;



            }

        }
    }
}
