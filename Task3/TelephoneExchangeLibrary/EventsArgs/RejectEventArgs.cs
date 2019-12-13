using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary.EventsArgs
{
    public class RejectEventArgs: EventArgs, IIdentifiable
    {
        public Guid Id { get; }

        public int CallerNumber { get; }

        public RejectEventArgs(int callerNumber)
        {
            Id = Guid.NewGuid();
            CallerNumber = callerNumber;
        }
    }
}
