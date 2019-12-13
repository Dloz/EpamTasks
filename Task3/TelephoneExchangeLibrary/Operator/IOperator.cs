using System;
using System.Collections.Generic;
using System.Text;

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