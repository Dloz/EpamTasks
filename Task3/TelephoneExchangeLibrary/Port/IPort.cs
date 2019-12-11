using System;
using TelephoneExchangeLibrary.EventsArgs;

namespace TelephoneExchangeLibrary
{
    public interface IPort: IIdentifiable, IRejectable, IRespondable, ICallable
    {
        event EventHandler<CallEventArgs> IncomingCallEvent;
        event EventHandler<CallEventArgs> OutgoingCallEvent;
        event EventHandler<RespondEventArgs> RespondEvent;
        event EventHandler<RejectEventArgs> RejectEvent;

        PortStatus Status { get; }

        void Connect(object sender, EventArgs e);
        void Disconnect(object sender, EventArgs e);
    }
}