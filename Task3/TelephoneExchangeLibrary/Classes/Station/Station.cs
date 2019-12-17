using System;
using System.Collections.Generic;
using System.Linq;
using TelephoneExchangeLibrary.Enums.Port;
using TelephoneExchangeLibrary.EventsArgs;
using TelephoneExchangeLibrary.Interfaces.CallHandler;
using TelephoneExchangeLibrary.Interfaces.Port;
using TelephoneExchangeLibrary.Interfaces.Station;
using TelephoneExchangeLibrary.Interfaces.Terminal;

namespace TelephoneExchangeLibrary.Classes.Station
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
        public IEnumerable<IPort> Ports => _ports;

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

        public void AddPort(IPort port)
        {
            if (port == null)
            {
                return;
            }
            _ports.Add(port);
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
            port.ConnectEvent += OnPortConnect;
            port.DisconnectEvent += OnPortDisconnect;

            return port;
        }

        private void OnPortConnect(object sender, EventArgs e) 
        {
            var port = ((IPort)sender);
            port.Status = PortStatus.Connected;
            _ports.Add(port);
        }

        private void OnPortDisconnect(object sender, EventArgs e)
        {
            var port = ((IPort)sender);
            if (_ports.Contains(port))
            {
                _ports.First(p => p.Id == port.Id).Status = PortStatus.Disconnected;
            }
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