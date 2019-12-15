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
        
        /// <summary>
        /// Represents current connected ports in the station.
        /// </summary>
        private readonly ICollection<IPort> _ports;

        /// <summary>
        /// Represents collection of ports.
        /// </summary>
        public IEnumerable<IPort> Ports => _ports.AsEnumerable();

        /// <summary>
        /// Station identifier.
        /// </summary>
        public Guid Id { get; }

        private Station()
        {
            Id = Guid.NewGuid();
            _ports = new List<IPort>();
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

            _ports.Add(port);

            port.IncomingCallEvent += terminal.IncomingCall;
            port.OutgoingCallEvent += HandleCall;
            port.RejectEvent += HandleReject;
            port.RespondEvent += HandleRespond;
            port.ConnectEvent += Port_Connect;
            port.DisconnectEvent += Port_Disconnect;

            return port;

        }

        private void Port_Connect(object sender, EventArgs e)
        {
            var port = ((IPort)sender);
            if (!_ports.Contains(port))
            {
                _ports.Add(port);
            }
        }

        private void Port_Disconnect(object sender, EventArgs e)
        {
            var port = ((IPort)sender);
            _ports.Remove(port);
        }

        /// <summary>
        /// Receive port from the station.
        /// </summary>
        /// <param name="id">Port identifier.</param>
        public IPort GetPort(Guid id)
        {
            return _ports.FirstOrDefault(p => p.Id == id);
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