using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary
{
    public interface IClient
    {
        ITerminal Terminal { get; }
        ICollection<IContract> Contracts { get; }
        void ReceiveTerminal(ITerminal terminal);
        void ReceiveContract(IContract contract);
        void ConnectTerminal();
        void DisconnectTerminal();
    }
}