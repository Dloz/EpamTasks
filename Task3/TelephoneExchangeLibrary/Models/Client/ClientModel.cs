using System.Collections.Generic;
using TelephoneExchangeLibrary.Interfaces.Client;
using TelephoneExchangeLibrary.Interfaces.Contract;
using TelephoneExchangeLibrary.Interfaces.Terminal;

namespace TelephoneExchangeLibrary.Models.Client
{
    public class ClientModel : IClient
    {
        /// <summary>
        /// Represents terminal client owns.
        /// </summary>
        public ICollection<ITerminal> Terminals { get; private set; }
        
        /// <summary>
        /// Represents collection of user contracts.
        /// </summary>
        public ICollection<IContract> Contracts { get; }

        public ClientModel()
        {
            Terminals = new List<ITerminal>();
            Contracts = new List<IContract>();
        }

    }
}