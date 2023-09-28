using System.Net.Mail;

namespace Eshop.Web.Services;

public static class EmailSenderService
{
    // https://myaccount.google.com/apppasswords
    public static bool SendEmail(string to, string subject, string body)
    {
        string email = "mohammad1375ordo@gmail.com";
        string password = "ckwosegvilgkzuey";
        string displayName = "سایت فروشگاه من";
        string smtp = "smtp.gmail.com";
        int port = 587;
        
        try
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient(smtp);
            mail.From = new MailAddress(email, displayName);
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            SmtpServer.Port = port;
            SmtpServer.EnableSsl = true;
            SmtpServer.Credentials = new System.Net.NetworkCredential(email, password);
            SmtpServer.Send(mail);
            return true;
        }
        catch
        {
            return false;
        }
    }
}