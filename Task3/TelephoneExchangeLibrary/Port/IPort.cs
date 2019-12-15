using System;
using TelephoneExchangeLibrary.EventsArgs;
using TelephoneExchangeLibrary.Terminal;

namespace TelephoneExchangeLibrary.Port
{
    public interface IPort: IIdentifiable
    {
        /// <summary>
        /// Represents terminal connected to the port.
        /// </summary>
        ITerminal Terminal { get;  }
        
        /// <summary>
        /// Represents current status of the port.
        /// </summary>
        PortStatus Status { get; }

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
        /// Notify about incoming call.
        /// </summary>
        /// <param name="e"></param>
        void IncomingCall(CallEventArgs e);
        
        /// <summary>
        /// Connect terminal to the port.
        /// </summary>
        void ConnectTerminal(ITerminal terminal);
        
        /// <summary>
        /// Connect the port to a station.
        /// </summary>
        void Connect(object sender, EventArgs e);
        
        /// <summary>
        /// Disconnect the port from a station.
        /// </summary>
        void Disconnect(object sender, EventArgs e);
    }
}