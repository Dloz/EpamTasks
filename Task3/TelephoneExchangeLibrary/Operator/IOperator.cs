using System.Collections.Generic;
using TelephoneExchangeLibrary.BillingSystem;
using TelephoneExchangeLibrary.Client;
using TelephoneExchangeLibrary.Station;

namespace TelephoneExchangeLibrary.Operator
{
    public interface IOperator
    {
        /// <summary>
        /// Represents billing system connected to the operator.
        /// </summary>
        IBillingSystem BillingSystem { get; }
        
        /// <summary>
        /// Represents collection of station.
        /// </summary>
        ICollection<IStation> Stations { get; } 
        
        /// <summary>
        /// Represents registered clients.
        /// </summary>
        ICollection<IClient> Clients { get; }
        
        /// <summary>
        /// Sign a contract with a client.
        /// </summary>
        void SignContract(IClient client);
    }
}