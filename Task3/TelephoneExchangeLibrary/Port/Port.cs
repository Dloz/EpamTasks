using System;
using System.Collections.Generic;
using System.Text;
using TelephoneExchangeLibrary.EventsArgs;

namespace TelephoneExchangeLibrary
{
    public class Port : IPort
    {
        public PortStatus Status { get; private set; }
        public Guid Id { get; }

        public event EventHandler<CallEventArgs> OutgoingCallEvent;
        public event EventHandler<CallEventArgs> IncomingCallEvent;
        public event EventHandler<RespondEventArgs> RespondEvent;
        public event EventHandler<RejectEventArgs> RejectEvent;

        public Port()
        {
            Id = Guid.NewGuid();
        }

        public void IncomingCall(object sender, CallEventArgs e)
        {
            IncomingCallEvent?.Invoke(this, e);
        }

        public void OutgoingCall(object sender, CallEventArgs e)
        {
            OutgoingCallEvent?.Invoke(this, e);
        }

        public void Reject(object sender, RejectEventArgs e)
        {
            RejectEvent?.Invoke(this, e);
        }

        public void Respond(object sender, RespondEventArgs e)
        {
            RespondEvent?.Invoke(this, e);
        }
        public void Connect(object sender, EventArgs e)
        {
            Status = PortStatus.Connected;
        }

        public void Disconnect(object sender, EventArgs e)
        {
            Status = PortStatus.Disconnected;
        }
    }
}