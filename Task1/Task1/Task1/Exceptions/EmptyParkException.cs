using System;
using System.Collections.Generic;
using System.Text;

namespace Task1.Exceptions
{
    class EmptyParkException : Exception
    {
        public EmptyParkException(string message) : base(message)
        {
        }
    }
}
