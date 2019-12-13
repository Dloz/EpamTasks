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
        public ITerminal Terminal { get; private set; }

        public event EventHandler<CallEventArgs> OutgoingCallEvent;
        public event EventHandler<CallEventArgs> IncomingCallEvent;
        public event EventHandler<RespondEventArgs> RespondEvent;
        public event EventHandler<RejectEventArgs> RejectEvent;

        public Port()
        {
            Id = Guid.NewGuid();
        } 

        public void Connect(object sender, EventArgs e)
        {
            Status = PortStatus.Connected;
        }

        public void Disconnect(object sender, EventArgs e)
        {
            Status = PortStatus.Disconnected;
        }

        public void ConnectTerminal(ITerminal terminal)
        {
            IncomingCallEvent += terminal.IncomingCall;
            terminal.OutgoingCallEvent += OutgoingCall;
            terminal.RespondEvent += Respond;
            terminal.RejectEvent += Reject;
            Terminal = terminal;
        }

        public void IncomingCall(CallEventArgs e)
        {
            IncomingCallEvent?.Invoke(this, e);
        }

        private void OutgoingCall(object sender, CallEventArgs e)
        {
            e = new CallEventArgs(Id, e.TargetNumber);
            OutgoingCallEvent?.Invoke(this, e);
        }

        private void Reject(object sender, RejectEventArgs e)
        {
            RejectEvent?.Invoke(this, e);
        }

        private void Respond(object sender, RespondEventArgs e)
        {
            RespondEvent?.Invoke(this, e);
        }

    }
}