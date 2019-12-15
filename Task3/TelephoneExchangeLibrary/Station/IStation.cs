using System;
using System.Collections.Generic;
using TelephoneExchangeLibrary.Port;
using TelephoneExchangeLibrary.Terminal;

namespace TelephoneExchangeLibrary.Station
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
        /// Receive port from the station.
        /// </summary>
        /// <param name="id">Port identifier.</param>
        IPort GetPort(Guid id);
    }
}