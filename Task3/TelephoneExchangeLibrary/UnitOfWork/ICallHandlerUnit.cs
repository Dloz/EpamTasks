using System;
using System.Collections.Generic;
using System.Text;
using TelephoneExchangeLibrary.EventsArgs;

namespace TelephoneExchangeLibrary
{
    public interface ICallHandlerUnit
    {
        void HandleCall(CallEventArgs callEventArgs);
        void HandleRespond(RespondEventArgs respondEventArgs);
        void HandleReject(RejectEventArgs rejectEventArgs);
    }
}