using System;
using System.Collections.Generic;
using System.Text;
using TelephoneExchangeLibrary.EventsArgs;

namespace TelephoneExchangeLibrary.UnitOfWork
{
    class CallHandlerUnit : UnitOfWork, ICallHandlerUnit
    {
        public void HandleCall(IPort port, CallEventArgs callEventArgs)
        {
            phoneOperator.Clients.
        }
    }
}
