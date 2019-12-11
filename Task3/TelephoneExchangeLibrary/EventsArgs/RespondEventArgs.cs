using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary.EventsArgs
{
    public class RespondEventArgs: EventArgs
    {
        public int CallerNumber { get; }

        public RespondEventArgs(int callerNumber)
        {
            CallerNumber = callerNumber;
        }
    }
}
