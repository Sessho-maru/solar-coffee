using System;

namespace SolarCoffee.Services
{
    public class ServiceResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
        public T Data { get; set; }

        static public ServiceResponse<T> Successed(T data, String message)
        {
            return new ServiceResponse<T> {
                Data = data,
                Time = DateTime.UtcNow,
                Message = message,
                IsSuccess = true
            };
        }

        static public ServiceResponse<T> Failed(T data, String errorMessage)
        {
            return new ServiceResponse<T> {
                Data = data,
                Time = DateTime.UtcNow,
                Message = errorMessage,
                IsSuccess = false
            };
        }
    }
}