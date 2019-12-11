using System;
using System.Collections.Generic;
using System.Linq;
using TelephoneExchangeLibrary.EventsArgs;

namespace TelephoneExchangeLibrary
{
    public class Station : IStation
    {
        //private IDictionary<int, IPort>
        public ICollection<IPort> Ports { get; private set; }

        public void ConnectTerminal(ITerminal terminal)
        {
            var port = new Port();
            Ports.Add(port);

            port.IncomingCallEvent += terminal.IncomingCall;
            port.OutgoingCallEvent += HandleCall;
            port.RejectEvent += HandleReject;
            port.RespondEvent += HandleRespond;

            terminal.OutgoingCallEvent += port.OutgoingCall;
            terminal.RespondEvent += port.Respond;
            terminal.RejectEvent += port.Reject;
        }

        private void HandleCall(object sender, CallEventArgs callEventArgs)
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