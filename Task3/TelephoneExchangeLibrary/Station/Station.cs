using System;
using System.Collections.Generic;
using System.Linq;
using TelephoneExchangeLibrary.EventsArgs;

namespace TelephoneExchangeLibrary
{
    public class Station : IStation
    {
        private IStation station;
        private IDictionary<int, IPort> userPorts; // contract - key. or contractId
        public ICollection<IPort> Ports { get; private set; }

        public Guid Id { get; }

        public Station()
        {
            Id = Guid.NewGuid();
        }

        public void ConnectTerminal(ITerminal terminal)
        {
            var port = new Port();
            Ports.Add(port);

            port.IncomingCallEvent += terminal.IncomingCall;
            port.OutgoingCallEvent += HandleCall;
            port.RejectEvent += HandleReject;
            port.RespondEvent += HandleRespond;


        }

        public IPort GetPort(Guid id)
        {
            return Ports.FirstOrDefault(p => p.Id == id);
        }

        private void HandleCall(object sender, CallEventArgs e)
        {
            
        }

        private void HandleReject(object sender, RejectEventArgs callEventArgs)
        {

        }
        private void HandleRespond(object sender, RespondEventArgs callEventArgs)
        {

        }
    }
}