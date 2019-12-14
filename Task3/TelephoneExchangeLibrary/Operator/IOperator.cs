using System;
using System.Collections.Generic;
using System.Text;
using TelephoneExchangeLibrary.BillingSystem;

namespace TelephoneExchangeLibrary
{
    public interface IOperator
    {
        IBillingSystem BillingSystem { get; }
        ICollection<IStation> Stations { get; } 
        ICollection<IClient> Clients { get; }
        void SignContract(IClient client);
    }
}