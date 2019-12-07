using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary
{
    public abstract class UnitOfWork
    {
        protected IStation station;

        public void RegisterStation(IStation station)
        {
            this.station = station;
        }

        public void RegisterBillingSystem()
        {
            throw new System.NotImplementedException();
        }
    }
}