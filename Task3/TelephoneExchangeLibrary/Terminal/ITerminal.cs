using System;
using TelephoneExchangeLibrary.EventsArgs;

namespace TelephoneExchangeLibrary.Terminal
{
    public interface ITerminal: IIdentifiable, ITerminalEvents
    {
        /// <summary>
        /// Terminal number.
        /// </summary>
        int Number { get; }

        /// <summary>
        /// Method to call other client.
        /// </summary>
        /// <param name="targetNumber"></param>
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
        /// Notification about incoming call
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void IncomingCall(object sender, CallEventArgs e);
        
        /// <summary>
        /// Connects terminal to the port.
        /// </summary>
        void Connect();
        
        /// <summary>
        /// Disconnects terminal from a port.
        /// </summary>
        void Disconnect();
    }
}