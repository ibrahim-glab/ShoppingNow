
namespace ShoppingNow.Service.Helper
{
    public class ServiceResult<T>(T data, string message = "", bool isSuccessful = false)
    {
        public T Data { get; } = data;
        public string Message { get; } = message;
        public bool IsSuccessful { get; } = isSuccessful;
    }
}
