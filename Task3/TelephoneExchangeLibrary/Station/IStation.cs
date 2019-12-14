using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary
{
    public interface IStation: IIdentifiable
    {
        ICollection<IPort> Ports { get; }
        /// <summary>
        /// Represents method which connects terminal to the station.
        /// </summary>
        /// <returns>Port in which terminal connected.</returns>
        IPort ConnectTerminal(ITerminal terminal);
    }
}