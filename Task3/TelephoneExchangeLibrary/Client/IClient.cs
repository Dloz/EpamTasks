using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary
{
    public interface IClient
    {
        int Terminal { get; set; }
        ICollection<IContract> Contracts { get; set; }

        void Call(); // terminal.InvokeCallEvent(number) --->  port.InvokeCallEvent()
        void ConnectTerminal();
        void DisconnectTerminal();
    }
}