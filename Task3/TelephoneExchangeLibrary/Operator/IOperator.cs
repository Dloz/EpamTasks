using System.Collections;
using System.Collections.Generic;
using TelephoneExchangeLibrary.BillingSystem;
using TelephoneExchangeLibrary.BillingSystem.TariffPlan;
using TelephoneExchangeLibrary.Client;
using TelephoneExchangeLibrary.Station;
using TelephoneExchangeLibrary.UnitOfWork.Reporter.CallReport;

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
        
        /// <summary>
        /// Sign a contract with a client.
        /// </summary>
        void SignContract(IClient client, ITariffPlan tariffPlan);

        ICollection<ICallReport> GetReport(IClient client);
    }
}