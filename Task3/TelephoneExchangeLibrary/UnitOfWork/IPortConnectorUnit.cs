using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary
{
    public interface IPortConnectorUnit
    {
        void ConnectPort();
        void DisconnectPort();
    }
}