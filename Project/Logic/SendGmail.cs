using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Project.Logic
{
    public static class SendGmail
    {
        public static async Task<string> SendMailGoogleSmtp(string _from, string _to, string _subject,
                                                            string _body, string _gmailsend, string _gmailpassword)
        {
            
                MailMessage message = new MailMessage(
                from: _from,
                to: _to,
                subject: _subject,
                body: _body
            );
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;
            message.ReplyToList.Add(new MailAddress(_from));
            message.Sender = new MailAddress(_from);

            // Tạo SmtpClient kết nối đến smtp.gmail.com
            using var SmtpClient = new SmtpClient("smtp.gmail.com");
            SmtpClient.Port = 587;
            SmtpClient.Credentials = new NetworkCredential(_gmailsend, _gmailpassword);
            SmtpClient.EnableSsl = true;

            try
            {
                await SmtpClient.SendMailAsync(message);
                return "thanh cong";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "that bai";
            }
        }
    }
}
