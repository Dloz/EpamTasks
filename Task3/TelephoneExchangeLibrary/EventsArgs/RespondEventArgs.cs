using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary.EventsArgs
{
    public class RespondEventArgs: EventArgs, IIdentifiable
    {
        
        public int ResponderNumber { get; }

        public Guid Id { get; }

        public RespondEventArgs(int callerNumber)
        {
            Id = Guid.NewGuid();
            ResponderNumber = callerNumber;
        }
    }
}
