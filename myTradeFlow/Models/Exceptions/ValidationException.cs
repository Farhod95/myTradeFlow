using System.Runtime.Serialization;

namespace myTradeFlow.Models.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException()
        { }

        public ValidationException(string? message) : base(message)
        { }

        public ValidationException(string? message, Exception? innerException) : base(message, innerException)
        { }
    }
}
