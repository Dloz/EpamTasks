﻿using System;
using TelephoneExchangeLibrary.EventsArgs;

namespace TelephoneExchangeLibrary.Interfaces.Terminal
{
    public interface ITerminal: IIdentifiable
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

        #region TerminalEvents
        /// <summary>
        /// Event that reacts to the incoming calls.
        /// </summary>
        event EventHandler<CallEventArgs> IncomingCallEvent;

        /// <summary>
        /// Event raised when outgoing calls occured.
        /// </summary>
        event EventHandler<CallEventArgs> OutgoingCallEvent;

        /// <summary>
        /// Event raised when respond occured.
        /// </summary>
        event EventHandler<RespondEventArgs> RespondEvent;

        /// <summary>
        /// Event raised when reject occured.
        /// </summary>
        event EventHandler<RejectEventArgs> RejectEvent;

        /// <summary>
        /// Notification about connecting to the port.
        /// </summary>
        event EventHandler<EventArgs> ConnectEvent;
        /// <summary>
        /// Notification about disconnecting from the port.
        /// </summary>
        event EventHandler<EventArgs> DisconnectEvent;
        #endregion
    }
}