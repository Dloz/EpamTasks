using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary.EventsArgs
{
    public class CallEventArgs: EventArgs, IIdentifiable
    {
        public Guid Id { get; }
        /// <summary>
        /// Represents id of the port which calling.
        /// </summary>
        public Guid PortId { get; }
        /// <summary>
        /// Represents phone number to be called.
        /// </summary>
        public int TargetNumber { get; }

        public CallEventArgs(Guid portId, int targetNumber)
        {
            Id = Guid.NewGuid();
            PortId = portId;
            TargetNumber = targetNumber;
        }
    }
}
