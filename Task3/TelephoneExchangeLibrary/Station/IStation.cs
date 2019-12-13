using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary
{
    public interface IStation: IIdentifiable
    {
        ICollection<IPort> Ports { get; }
        void ConnectTerminal(ITerminal terminal);
    }
}