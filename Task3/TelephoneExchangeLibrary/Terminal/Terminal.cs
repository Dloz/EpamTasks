using System;
using System.Collections.Generic;
using System.Text;
using TelephoneExchangeLibrary.EventsArgs;

namespace TelephoneExchangeLibrary
{
    public class Terminal : ITerminal
    {
        public Guid Id => throw new NotImplementedException();

        public event EventHandler IncomingCallEvent;
        public event EventHandler OutgoingCallEvent;
        public event EventHandler RespondEvent;
        public event EventHandler RejectEvent;

        public void IncomingCall(object sender, CallEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void OutgoingCall(object sender, CallEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Reject(object sender, RejectEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Respond(object sender, RespondEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}