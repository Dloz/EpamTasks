using System;
using System.Collections.Generic;
using System.Text;
using TelephoneExchangeLibrary.EventsArgs;

namespace TelephoneExchangeLibrary
{
    public interface ICallable
    {
        void OutgoingCall(object sender, CallEventArgs e);
        void IncomingCall(object sender, CallEventArgs e);
    }
}