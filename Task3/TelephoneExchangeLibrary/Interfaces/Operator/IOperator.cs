using System;
using System.Collections.Generic;
using TelephoneExchangeLibrary.Interfaces.CallReport;
using TelephoneExchangeLibrary.Interfaces.Client;
using TelephoneExchangeLibrary.Interfaces.Contract;
using TelephoneExchangeLibrary.Interfaces.TariffPlan;
using TelephoneExchangeLibrary.Interfaces.Terminal;

namespace TelephoneExchangeLibrary.Interfaces.Operator
{
    public interface IOperator
    {        
        /// <summary>
        /// Represents registered clients.
        /// </summary>
        ICollection<IClient> Clients { get; } // encapsulate
        
        /// <summary>
        /// Sign a contract with a client.
        /// </summary>
        ValueTuple<IContract, ITerminal> SignContract(ITariffPlan tariffPlan, IClient client = null);

        ICollection<ICallReport> GetReport(IClient client);
    }
}