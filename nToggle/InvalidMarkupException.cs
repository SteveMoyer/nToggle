using System;

namespace nToggle
{
    public class InvalidMarkupException : ApplicationException
    {
        public InvalidMarkupException(string message)
            : base(message)
        {
        }
    }
}