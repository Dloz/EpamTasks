using System.Collections.Generic;
using TelephoneExchangeLibrary.Terminal;

namespace TelephoneExchangeLibrary.Client
{
    public interface IClient
    {
        /// <summary>
        /// Represents terminal client owns.
        /// </summary>
        ITerminal Terminal { get; }
        
        /// <summary>
        /// Represents collection of user contracts.
        /// </summary>
        ICollection<IContract> Contracts { get; }

        /// <summary>
        /// Method to call other client.
        /// </summary>
        /// <param name="targetNumber">Number to be called.</param>
        void Call(int targetNumber);
        
        /// <summary>
        /// Method to respond on incoming call.
        /// </summary>
        void Respond();
        
        /// <summary>
        /// Method to reject active or incoming call.
        /// </summary>
        void Reject();
        
        /// <summary>
        /// Receive terminal from operator.
        /// </summary>
        /// <param name="terminal"></param>
        void ReceiveTerminal(ITerminal terminal);
        
        /// <summary>
        /// Receive contract from operator.
        /// </summary>
        /// <param name="contract"></param>
        void ReceiveContract(IContract contract);
        
        /// <summary>
        /// Connect Terminal to a port.
        /// </summary>
        void ConnectTerminal();
        
        /// <summary>
        /// Disconnect terminal from a port.
        /// </summary>
        void DisconnectTerminal();
    }
}