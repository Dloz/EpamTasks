using System;
using System.Collections.Generic;
using System.Text;
using TelephoneExchangeLibrary.BillingSystem;
using TelephoneExchangeLibrary.Operator;
using TelephoneExchangeLibrary.Station;

namespace TelephoneExchangeLibrary.UnitOfWork
{
    public abstract class UnitOfWork
    {
        protected IStation Station;
        protected IBillingSystem BillingSystem;
        protected IOperator PhoneOperator;

        public void RegisterStation(IStation station)
        {
            if (station != null)
            {
                this.Station = station; 
            }
        }

        public void RegisterBillingSystem(IBillingSystem billingSystem)
        {
            if (billingSystem != null)
            {
                this.BillingSystem = billingSystem; 
            }
        }

        public void RegisterOperator(IOperator phoneOperator)
        {
            if (phoneOperator != null)
            {
                this.PhoneOperator = phoneOperator; 
            }
        }
    }
}