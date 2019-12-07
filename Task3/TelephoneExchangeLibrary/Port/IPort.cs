using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary
{
    public interface IPort: IIdentifiable
    {
        event EventHandler RespondEvent;
        event EventHandler IncomingCallEvent;
        event EventHandler OutgoingCallEvent;
        event EventHandler RejectEvent;

        int Status { get; set; }
    }
}