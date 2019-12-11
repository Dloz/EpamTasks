using System;
using System.Collections.Generic;
using System.Text;
using TelephoneExchangeLibrary.EventsArgs;

namespace TelephoneExchangeLibrary
{
    public class Terminal : ITerminal
    {
        public Guid Id { get; }

        public event EventHandler<CallEventArgs> IncomingCallEvent;
        public event EventHandler<CallEventArgs> OutgoingCallEvent;
        public event EventHandler<RespondEventArgs> RespondEvent;
        public event EventHandler<RejectEventArgs> RejectEvent;

        public Terminal()
        {
            Id = Guid.NewGuid();
        }

        public void IncomingCall(object sender, CallEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void OutgoingCall(int callerNumber, int targetNumber)
        {
            OutgoingCallEvent?.Invoke(this, new CallEventArgs(callerNumber, targetNumber));
        }

        public void Reject()
        {
            RejectEvent?.Invoke(this, new RejectEventArgs());
        }

        public void Respond()
        {
            RespondEvent?.Invoke(this, new RespondEventArgs());
        }
    }
}