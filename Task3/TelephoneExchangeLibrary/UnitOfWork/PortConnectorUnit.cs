using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary
{
    public class PortConnectorUnit : UnitOfWork, IPortConnectorUnit
    {
        public PortConnectorUnit(IStation station)
        {
            base.RegisterStation(station);
        }
        public void ConnectPort()
        {
            throw new NotImplementedException();
        }

        public void DisconnectPort()
        {
            throw new NotImplementedException();
        }
    }
}