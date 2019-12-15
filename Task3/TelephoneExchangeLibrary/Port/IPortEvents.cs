using System;
using TelephoneExchangeLibrary.EventsArgs;

namespace TelephoneExchangeLibrary.Port
{
    public interface IPortEvents
    {
        /// <summary>
        /// Event that reacts to the incoming calls.
        /// </summary>
        event EventHandler<CallEventArgs> IncomingCallEvent;
        
        /// <summary>
        /// Event raised when outgoing calls occured.
        /// </summary>
        event EventHandler<CallEventArgs> OutgoingCallEvent;
        
        /// <summary>
        /// Event raised when respond occured.
        /// </summary>
        event EventHandler<RespondEventArgs> RespondEvent;
        
        /// <summary>
        /// Event raised when reject occured.
        /// </summary>
        event EventHandler<RejectEventArgs> RejectEvent;

        /// <summary>
        /// Notification about connecting to the port.
        /// </summary>
        event EventHandler<EventArgs> ConnectEvent;
        
        /// <summary>
        /// Notification about disconnecting from the port.
        /// </summary>
        event EventHandler<EventArgs> DisconnectEvent;
    }
}