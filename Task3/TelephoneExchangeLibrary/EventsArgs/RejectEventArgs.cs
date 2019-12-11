using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary.EventsArgs
{
    public class RejectEventArgs: EventArgs
    {
        public int CallerNumber { get; }

        public RejectEventArgs(int callerNumber)
        {
            CallerNumber = callerNumber;
        }
    }
}
