using System;
using System.Collections.Generic;
using System.Text;
using TelephoneExchangeLibrary.EventsArgs;

namespace TelephoneExchangeLibrary
{
    public interface ITerminal: IIdentifiable
    {
        int Number { get; }

        event EventHandler<CallEventArgs> IncomingCallEvent;
        event EventHandler<CallEventArgs> OutgoingCallEvent;
        event EventHandler<RespondEventArgs> RespondEvent;
        event EventHandler<RejectEventArgs> RejectEvent;

        void Call(int targetNumber);
        void Respond();
        void Reject();

        void IncomingCall(object sender, CallEventArgs e);
    }
}