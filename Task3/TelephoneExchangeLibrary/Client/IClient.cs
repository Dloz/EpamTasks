using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary
{
    public interface IClient: ICallable, IRejectable, IRespondable
    {
        ITerminal Terminal { get; set; }
        ICollection<IContract> Contracts { get; set; }

        void ConnectTerminal();
        void DisconnectTerminal();
    }
}