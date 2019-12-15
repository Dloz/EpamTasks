using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary.Exceptions
{
    /// <summary>
    /// Specifies exception connected with calls.
    /// </summary>
    class CallException: Exception
    {
        public override string Message { get; }

        public CallException(string message)
        {
            Message = message;
        }
    }
}
