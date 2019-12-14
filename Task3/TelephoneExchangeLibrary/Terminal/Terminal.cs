using System;
using System.Collections.Generic;
using System.Text;
using TelephoneExchangeLibrary.EventsArgs;

namespace TelephoneExchangeLibrary
{
    public class Terminal : ITerminal
    {
        public Guid Id { get; }
        public int Number { get; set; }

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
            // TODO Notify user about incoming call.
        }

        public void Call(int targetNumber)
        {
            OutgoingCallEvent?.Invoke(this, new CallEventArgs(Guid.NewGuid(), targetNumber));
        }

        public void Reject()
        {
            RejectEvent?.Invoke(this, new RejectEventArgs(Number));
        }

        public void Respond()
        {
            RespondEvent?.Invoke(this, new RespondEventArgs(Number));
        }
    }
}