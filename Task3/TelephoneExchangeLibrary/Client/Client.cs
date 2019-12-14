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

        public Client()
        {
            Contracts = new List<IContract>();
        }

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
                Terminal.IncomingCallEvent += IncomingCall;
            }
        }

        private void IncomingCall(object sender, CallEventArgs e)
        {
            throw new NotImplementedException();// Notify user about incomming call.
        }

        public void ConnectTerminal()
        {
            
        }

        public void DisconnectTerminal()
        {
            throw new NotImplementedException();
        }

        public void Call(int targetNumber)
        {
            Terminal.Call(targetNumber);
        }

        public void Reject()
        {
            Terminal.Reject();
        }

        public void Respond()
        {
            Terminal.Respond();
        }
    }
}