using System;
using System.Collections.Generic;
using System.Text;
using TelephoneExchangeLibrary.EventsArgs;

namespace TelephoneExchangeLibrary
{
    public interface ITerminal: IIdentifiable, ICallable
    {
        event EventHandler<CallEventArgs> IncomingCallEvent;
        event EventHandler<CallEventArgs> OutgoingCallEvent;
        event EventHandler<RespondEventArgs> RespondEvent;
        event EventHandler<RejectEventArgs> RejectEvent;
    }
}