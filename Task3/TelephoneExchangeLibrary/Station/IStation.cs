using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary
{
    public interface IStation
    {
        event EventHandler CallEvent;
        event EventHandler PortDisconnectedEvent;
        event EventHandler PortConnectedEvent;

        int Ports { get; set; }
    }
}