using System;
using System.Collections.Generic;

namespace TelephoneExchangeLibrary
{
    public class Station : IStation
    {
        public ICollection<IPort> Ports => throw new NotImplementedException();

        public void ConnectTerminal(ITerminal terminal)
        {

        }
    }
}