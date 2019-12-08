﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary
{
    public interface ITerminal: IIdentifiable, ICallable, IRespondable, IRejectable
    {
        event EventHandler IncomingCallEvent;
        event EventHandler OutgoingCallEvent;
        event EventHandler RespondEvent;
        event EventHandler RejectEvent;
    }
}