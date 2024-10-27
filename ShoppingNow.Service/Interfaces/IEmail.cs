namespace ShoppingNow.Service.Interfaces;

public interface IEmail
{
    public Task Send(string from, string to, string subject, string body);
}