using System;
using System.Collections.Generic;
using System.Linq;
using TelephoneExchangeLibrary.EventsArgs;

namespace TelephoneExchangeLibrary
{
    public class Station : IStation
    {
        private ICallHandlerUnit callHandler;
        private IDictionary<int, IPort> userPorts; // contract - key. or contractId
        public ICollection<IPort> Ports { get; private set; }

        public Guid Id { get; }

        public Station()
        {
            Id = Guid.NewGuid();
            Ports = new List<IPort>();
        }

        public Station(ICallHandlerUnit callHandler): this()
        {
            this.callHandler = callHandler;
        }

        public IPort ConnectTerminal(ITerminal terminal)
        {
            var port = new Port();
            port.ConnectTerminal(terminal);

            Ports.Add(port);

            port.IncomingCallEvent += terminal.IncomingCall;
            port.OutgoingCallEvent += HandleCall;
            port.RejectEvent += HandleReject;
            port.RespondEvent += HandleRespond;

            return port;

        }

        public IPort GetPort(Guid id)
        {
            return Ports.FirstOrDefault(p => p.Id == id);
        }

        private void HandleCall(object sender, CallEventArgs e)
        {
            callHandler.HandleCall(e);
        }

        private void HandleReject(object sender, RejectEventArgs e)
        {
            callHandler.HandleReject(e);
        }
        private void HandleRespond(object sender, RespondEventArgs e)
        {
            callHandler.HandleRespond(e);
        }
    }
}