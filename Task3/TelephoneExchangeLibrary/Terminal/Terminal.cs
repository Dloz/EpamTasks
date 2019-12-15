using System;
using TelephoneExchangeLibrary.EventsArgs;
using TelephoneExchangeLibrary.Exceptions;

namespace TelephoneExchangeLibrary.Terminal
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

        public Terminal()
        {
            Id = Guid.NewGuid();
        }

        public void IncomingCall(object sender, CallEventArgs e)
        {
            _incomingCallId = e.Id;
            IncomingCallEvent.Invoke(sender, e);
        }

        public void Call(int targetNumber)
        {
            OutgoingCallEvent?.Invoke(this, new CallEventArgs(Guid.NewGuid(), targetNumber));
        }

        public void Reject()
        {
            if (_incomingCallId == Guid.Empty)
            {
                throw new NoIncomingCallException("Nothing to reject to.");
            }
            RejectEvent?.Invoke(this, new RejectEventArgs(Number, _incomingCallId));
        }

        public void Respond()
        {
            if (_incomingCallId == Guid.Empty)
            {
                throw new NoIncomingCallException("Nothing to respond to.");
            }
            RespondEvent?.Invoke(this, new RespondEventArgs(Number, _incomingCallId));
        }
    }
}