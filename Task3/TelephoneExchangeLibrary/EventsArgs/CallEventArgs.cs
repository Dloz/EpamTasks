using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary.EventsArgs
{
    public class CallEventArgs: EventArgs
    {
        public int CallerNumber { get; }
        public int TargetNumber { get; }

        public CallEventArgs(int callerNumber, int targetNumber)
        {
            CallerNumber = callerNumber;
            TargetNumber = targetNumber;
        }
    }
}
