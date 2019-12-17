using System;
using TelephoneExchangeLibrary.EventsArgs;
using TelephoneExchangeLibrary.Interfaces.Terminal;

namespace TelephoneExchangeLibrary.Classes.Terminal
{
    public class Terminal : ITerminal
    {
        /// <summary>
        /// Represents incoming call id. Empty field means no incoming calls.
        /// </summary>
        private Guid _incomingCallId = Guid.Empty;

        /// <summary>
        /// Terminal identifier.
        /// </summary>
        public Guid Id { get; }
        
        /// <summary>
        /// Terminal number.
        /// </summary>
        public int Number { get; set; }

        #region TerminalEvents

        /// <summary>
        /// Event that reacts to the incoming calls.
        /// </summary>
        public event EventHandler<CallEventArgs> IncomingCallEvent;
        
        /// <summary>
        /// Event raised when outgoing calls occured.
        /// </summary>
        public event EventHandler<CallEventArgs> OutgoingCallEvent;
        
        /// <summary>
        /// Event raised when respond occured.
        /// </summary>
        public event EventHandler<RespondEventArgs> RespondEvent;
        
        /// <summary>
        /// Event raised when reject occured.
        /// </summary>
        public event EventHandler<RejectEventArgs> RejectEvent;
        
        /// <summary>
        /// Notification about connecting to the port.
        /// </summary>
        public event EventHandler<EventArgs> ConnectEvent;
        /// <summary>
        /// Notification about disconnecting from the port.
        /// </summary>
        public event EventHandler<EventArgs> DisconnectEvent;

        #endregion
        

        public Terminal()
        {
            Id = Guid.NewGuid();
        }
        
        /// <summary>
        /// Notification about incoming call.
        /// </summary>
        public void IncomingCall(object sender, CallEventArgs e)
        {
            _incomingCallId = e.Id;
            IncomingCallEvent?.Invoke(sender, e);
        }

        /// <summary>
        /// Connects terminal to the port.
        /// </summary>
        public void Connect()
        {
            ConnectEvent?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Disconnects terminal from a port.
        /// </summary>
        public void Disconnect()
        {
            DisconnectEvent?.Invoke(this, new EventArgs());
        }
        
        /// <summary>
        /// Method to call other client.
        /// </summary>
        /// <param name="targetNumber">Number to call.</param>
        public void Call(int targetNumber)
        {
            OutgoingCallEvent?.Invoke(this, new CallEventArgs(Guid.NewGuid(), targetNumber));
        }
        
        /// <summary>
        /// Method to reject active or incoming call.
        /// </summary>
        public void Reject()
        {
            RejectEvent?.Invoke(this, new RejectEventArgs(Number, _incomingCallId));
        }
        
        /// <summary>
        /// Method to respond on incoming call.
        /// </summary>
        public void Respond()
        {
            if (_incomingCallId == Guid.Empty)
            {
                return; // TODO Error codes
            }
            RespondEvent?.Invoke(this, new RespondEventArgs(Number, _incomingCallId));
        }
    }
}