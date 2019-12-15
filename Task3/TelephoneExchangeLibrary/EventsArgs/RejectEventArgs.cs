using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary.EventsArgs
{
    public class RejectEventArgs: EventArgs, IIdentifiable
    {
        /// <summary>
        /// Call identifier.
        /// </summary>
        public Guid Id { get; }
        
        /// <summary>
        /// Phone number of user that calls.
        /// </summary>
        public int CallerNumber { get; }

        public RejectEventArgs(int callerNumber)
        {
            Id = Guid.NewGuid();
            CallerNumber = callerNumber;
        }

        public RejectEventArgs(int callerNumber, Guid id)
        {
            Id = id;
            CallerNumber = callerNumber;
        }
    }
}
