using System.Net.Mail;
using ShoppingNow.Service.Interfaces;

namespace ShoppingNow.Service.Services;

public class Email :IEmail
{
    public async Task Send(string from, string to, string subject, string body)
    {
        try
        {
            SmtpClient client = new SmtpClient();
            MailAddress sender = new MailAddress(from);
            MailAddress receiver = new MailAddress(to);
            MailMessage message = new MailMessage(sender, receiver);
            message.Body = body;
            message.Subject = subject;
            string userState = "test message1";

        await    Task.Run(() =>
        {
            client.SendAsync(message , userState);
        }) ;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}