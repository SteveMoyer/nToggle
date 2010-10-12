using System;
using System.Runtime.Serialization;

namespace nToggle
{
    public class InvalidMarkupException : ApplicationException
    {
        public InvalidMarkupException()
        {
            
        }
        public InvalidMarkupException(string message)
            : base(message)
        {
            
        }
        public InvalidMarkupException(string message, Exception innerException)
            : base(message, innerException)
        {
            
        }
        protected InvalidMarkupException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
            
        }

    }
}
