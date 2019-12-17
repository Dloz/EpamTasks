using TelephoneExchangeLibrary.Interfaces.BillingSystem;
using TelephoneExchangeLibrary.Interfaces.Operator;
using TelephoneExchangeLibrary.Interfaces.Station;

namespace TelephoneExchangeLibrary.Services
{
    public abstract class Service
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