using System.Collections.Generic;
using TelephoneExchangeLibrary.Interfaces.Port;
using TelephoneExchangeLibrary.Interfaces.Terminal;

namespace TelephoneExchangeLibrary.Interfaces.Station
{
    public interface IStation: IIdentifiable
    {
        /// <summary>
        /// Represents collection of ports.
        /// </summary>
        IEnumerable<IPort> Ports { get; }
        
        /// <summary>
        /// Represents method which connects terminal to the station.
        /// </summary>
        /// <returns>Port in which terminal connected.</returns>
        IPort ConnectTerminal(ITerminal terminal);
        
        /// <summary>
        /// Adds new port to the station.
        /// </summary>
        void AddPort(IPort port);
    }
}