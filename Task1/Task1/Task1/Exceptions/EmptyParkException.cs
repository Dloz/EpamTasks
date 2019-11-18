using System;

namespace Task1Library.Exceptions
{
    internal class EmptyParkException : Exception
    {
        public EmptyParkException(string message) : base(message)
        {
        }
    }
}
