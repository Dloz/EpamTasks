using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary
{
    public interface IStation
    {

        ICollection<IPort> Ports { get; }

        void ConnectTerminal(ITerminal terminal);
    }
}