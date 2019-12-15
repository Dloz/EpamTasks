using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary.EventsArgs
{
    public class RespondEventArgs: EventArgs, IIdentifiable
    {
        /// <summary>
        /// Call identifier.
        /// </summary>
        public Guid Id { get; }
        /// <summary>
        /// Phone number of call responder.
        /// </summary>
        public int ResponderNumber { get; }


        public RespondEventArgs(int callerNumber)
        {
            Id = Guid.NewGuid();
            ResponderNumber = callerNumber;
        }

        public RespondEventArgs(int callerNumber, Guid id)
        {
            Id = id;
            ResponderNumber = callerNumber;
        }
    }
}
