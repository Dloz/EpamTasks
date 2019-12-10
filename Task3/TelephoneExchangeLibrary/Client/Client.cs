using System;
using System.Collections.Generic;
using System.Text;
using TelephoneExchangeLibrary.EventsArgs;

namespace TelephoneExchangeLibrary
{
    public class Client : IClient
    {
        public ITerminal Terminal { get; private set; }
        public ICollection<IContract> Contracts { get; private set; }

        public void ReceiveContract(IContract contract)
        {
            if (contract != null)
            {
                Contracts.Add(contract);
            }
        }

        public void ReceiveTerminal(ITerminal terminal)
        {
            if (terminal != null)
            {
                Terminal = terminal;
            }
        }

        public void ConnectTerminal()
        {
            throw new NotImplementedException();
        }

        public void DisconnectTerminal()
        {
            throw new NotImplementedException();
        }

        public void IncomingCall(object sender, CallEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void OutgoingCall(object sender, CallEventArgs e)
        {
            throw new NotImplementedException();
        }


        public void Reject(object sender, RejectEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Respond(object sender, RespondEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}