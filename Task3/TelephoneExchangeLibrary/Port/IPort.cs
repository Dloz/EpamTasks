using System;
using TelephoneExchangeLibrary.EventsArgs;

namespace TelephoneExchangeLibrary
{
    public interface IPort: IIdentifiable, IRejectable, IRespondable, ICallable
    {
        event EventHandler IncomingCallEvent;
        event EventHandler OutgoingCallEvent;
        event EventHandler RespondEvent;
        event EventHandler RejectEvent;

        PortStatus Status { get; }

        void Connect(object sender, EventArgs e);
        void Disconnect(object sender, EventArgs e);
    }
}