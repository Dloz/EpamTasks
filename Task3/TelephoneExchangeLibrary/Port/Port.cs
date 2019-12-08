using System;
using System.Collections.Generic;
using System.Text;
using TelephoneExchangeLibrary.EventsArgs;

namespace TelephoneExchangeLibrary
{
    public class Port : IPort
    {
        public PortStatus Status { get; }
        public Guid Id { get; }

        public event EventHandler RespondEvent;
        public event EventHandler IncomingCallEvent;
        public event EventHandler OutgoingCallEvent;
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
        public void Connect(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Disconnect(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}