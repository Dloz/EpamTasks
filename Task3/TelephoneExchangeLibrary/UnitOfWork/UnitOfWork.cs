using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary.UnitOfWork
{
    public abstract class UnitOfWork
    {
        protected IStation station;
        protected IBillingSystem billingSystem;
        protected IOperator phoneOperator;

        public void RegisterStation(IStation station)
        {
            if (station != null)
            {
                this.station = station; 
            }
        }

        public void RegisterBillingSystem(IBillingSystem billingSystem)
        {
            if (billingSystem != null)
            {
                this.billingSystem = billingSystem; 
            }
        }

        public void RegisterOperator(IOperator phoneOperator)
        {
            if (phoneOperator != null)
            {
                this.phoneOperator = phoneOperator; 
            }
        }
    }
}