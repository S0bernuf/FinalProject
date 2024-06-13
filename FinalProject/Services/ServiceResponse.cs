
namespace FinalProject.BusinessLogic.Services
{
    public class ServiceResponse<T>
    {
        // Holds the data returned by the service operation, of generic type T
        public T Data { get; set; }
        // Indicates whether the service operation was successful
        public bool Success { get; set; }
        // Contains a message related to the service operation, typically used for error or success messages
        public string Message { get; set; }
    }
}
