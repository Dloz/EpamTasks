using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary
{
    public interface IClient
    {
        int Terminal { get; set; }
        int Contract { get; set; }

        void Call();
        void ConnectTerminal();
        void DisconnectTerminal();
    }
}