using System.Runtime.Serialization;

namespace myTradeFlow.Models.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException()
        { }

        public NotFoundException(string? message) : base(message)
        { }

        protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        { }
    }
}
