using System;
using System.Collections.Generic;
using System.Linq;
using TelephoneExchangeLibrary.EventsArgs;
using TelephoneExchangeLibrary.Port;
using TelephoneExchangeLibrary.Terminal;
using TelephoneExchangeLibrary.UnitOfWork;

namespace TelephoneExchangeLibrary.Station
{
    public class Station : IStation
    {
        /// <summary>
        /// Unit to handle calls inside the station.
        /// </summary>
        private readonly ICallHandlerUnit _callHandler;
        
        private IDictionary<int, IPort> _userPorts; // TODO contract - key. or contractId

        /// <summary>
        /// Represents collection of ports.
        /// </summary>
        public ICollection<IPort> Ports { get; private set; }

        /// <summary>
        /// Station identifier.
        /// </summary>
        public Guid Id { get; }

        private Station()
        {
            Id = Guid.NewGuid();
            Ports = new List<IPort>();
        }

        public Station(ICallHandlerUnit callHandler): this()
        {
            this._callHandler = callHandler;
        }
        
        /// <summary>
        /// Connects terminal to the port.
        /// </summary>
        /// <param name="terminal">Terminal to be connected.</param>
        /// <returns>Port which terminal connected in.</returns>
        public IPort ConnectTerminal(ITerminal terminal)
        {
            var port = new Port.Port();
            port.ConnectTerminal(terminal);

            Ports.Add(port);

            port.IncomingCallEvent += terminal.IncomingCall;
            port.OutgoingCallEvent += HandleCall;
            port.RejectEvent += HandleReject;
            port.RespondEvent += HandleRespond;

            return port;

        }

        /// <summary>
        /// Receive port from the station.
        /// </summary>
        /// <param name="id">Port identifier.</param>
        public IPort GetPort(Guid id)
        {
            return Ports.FirstOrDefault(p => p.Id == id);
        }

        private void HandleCall(object sender, CallEventArgs e)
        {
            _callHandler.HandleCall(e);
        }

        private void HandleReject(object sender, RejectEventArgs e)
        {
            _callHandler.HandleReject(e);
        }
        private void HandleRespond(object sender, RespondEventArgs e)
        {
            _callHandler.HandleRespond(e);
        }
    }
}