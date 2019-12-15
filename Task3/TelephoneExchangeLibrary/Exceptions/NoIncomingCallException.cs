using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary.Exceptions
{
    /// <summary>
    /// Specifies exception when client tries to react on unpresence incoming call.
    /// </summary>
    class NoIncomingCallException: Exception
    {
        public override string Message { get; }

        public NoIncomingCallException(string message)
        {
            Message = message;
        }
    }
}
