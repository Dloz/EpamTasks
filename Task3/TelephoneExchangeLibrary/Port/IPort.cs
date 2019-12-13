using System;
using TelephoneExchangeLibrary.EventsArgs;

namespace TelephoneExchangeLibrary
{
    public interface IPort: IIdentifiable
    {
        ITerminal Terminal { get;  }
        PortStatus Status { get; }

        event EventHandler<CallEventArgs> IncomingCallEvent;
        event EventHandler<CallEventArgs> OutgoingCallEvent;
        event EventHandler<RespondEventArgs> RespondEvent;
        event EventHandler<RejectEventArgs> RejectEvent;

        void IncomingCall(CallEventArgs e);
        void ConnectTerminal(ITerminal terminal);
        void Connect(object sender, EventArgs e);
        void Disconnect(object sender, EventArgs e);
    }
}