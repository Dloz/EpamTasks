using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary.EventsArgs
{
    public class CallEventArgs: EventArgs
    {
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
            PortId = portId;
            TargetNumber = targetNumber;
        }
    }
}
