using System;
using System.Collections.Generic;
using TelephoneExchangeLibrary.EventsArgs;
using TelephoneExchangeLibrary.Terminal;

namespace TelephoneExchangeLibrary.Client
{
    public class Client : IClient
    {
        /// <summary>
        /// Represents terminal client owns.
        /// </summary>
        public ITerminal Terminal { get; private set; }
        
        /// <summary>
        /// Represents collection of user contracts.
        /// </summary>
        public ICollection<IContract> Contracts { get; }

        public Client()
        {
            Contracts = new List<IContract>();
        }
        /// <summary>
        /// Connect Terminal to a port.
        /// </summary>
        public void ConnectTerminal()
        {
            
        }

        /// <summary>
        /// Disconnect terminal from a port.
        /// </summary>
        public void DisconnectTerminal()
        {
            throw new NotImplementedException();
        }
        
        
        /// <summary>
        /// Method to call other client.
        /// </summary>
        /// <param name="targetNumber">Number to be called.</param>
        public void Call(int targetNumber)
        {
            Terminal.Call(targetNumber);
        }

        /// <summary>
        /// Method to reject active or incoming call.
        /// </summary>
        public void Reject()
        {
            Terminal.Reject();
        }

        /// <summary>
        /// Method to respond on incoming call.
        /// </summary>
        public void Respond()
        {
            Terminal.Respond();
        }
        
        /// <summary>
        /// Receive contract from operator.
        /// </summary>
        /// <param name="contract"></param>
        public void ReceiveContract(IContract contract)
        {
            if (contract != null)
            {
                Contracts.Add(contract);
            }
        }

        /// <summary>
        /// Receive terminal from operator.
        /// </summary>
        /// <param name="terminal"></param>
        public void ReceiveTerminal(ITerminal terminal)
        {
            if (terminal == null) return;
            Terminal = terminal;
            Terminal.IncomingCallEvent += IncomingCall;
        }

        private void IncomingCall(object sender, CallEventArgs e)
        {
            // TODO notification
        }


    }
}