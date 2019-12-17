using System.Collections.Generic;
using TelephoneExchangeLibrary.Interfaces.Contract;
using TelephoneExchangeLibrary.Interfaces.Terminal;

namespace TelephoneExchangeLibrary.Interfaces.Client
{
    public interface IClient
    {
        /// <summary>
        /// Represents terminal client owns.
        /// </summary>
        ICollection<ITerminal> Terminals { get; } 
        
        /// <summary>
        /// Represents collection of user contracts.
        /// </summary>
        ICollection<IContract> Contracts { get; }
    }
}