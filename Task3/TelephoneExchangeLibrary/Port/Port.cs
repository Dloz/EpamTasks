﻿using System;
using TelephoneExchangeLibrary.EventsArgs;
using TelephoneExchangeLibrary.Terminal;

namespace TelephoneExchangeLibrary.Port
{
    public class Port : IPort
    {
        /// <summary>
        /// Represents current status of the port.
        /// </summary>
        public PortStatus Status { get; private set; }
        
        /// <summary>
        /// Port identifier.
        /// </summary>
        public Guid Id { get; }
        
        /// <summary>
        /// Represents terminal connected to the port.
        /// </summary>
        public ITerminal Terminal { get; private set; }

        /// <summary>
        /// Event that reacts to the incoming calls.
        /// </summary>
        public event EventHandler<CallEventArgs> IncomingCallEvent;
        
        /// <summary>
        /// Event raised when outgoing calls occured.
        /// </summary>
        public event EventHandler<CallEventArgs> OutgoingCallEvent;
        
        /// <summary>
        /// Event raised when respond occured.
        /// </summary>
        public event EventHandler<RespondEventArgs> RespondEvent;
        
        /// <summary>
        /// Event raised when reject occured.
        /// </summary>
        public event EventHandler<RejectEventArgs> RejectEvent;

        /// <summary>
        /// Notification about connecting to the port.
        /// </summary>
        public event EventHandler<EventArgs> ConnectEvent;
        /// <summary>
        /// Notification about disconnecting from the port.
        /// </summary>
        public event EventHandler<EventArgs> DisconnectEvent;

        public Port()
        {
            Status = PortStatus.Connected;
            Id = Guid.NewGuid();
        } 

        /// <summary>
        /// Connect the port to a station.
        /// </summary>
        public void Connect(object sender, EventArgs e)
        {
            Status = PortStatus.Connected;
            ConnectEvent?.Invoke(this, e);
        }

        /// <summary>
        /// Disconnect the port from a station.
        /// </summary>
        public void Disconnect(object sender, EventArgs e)
        {
            Status = PortStatus.Disconnected;
            DisconnectEvent?.Invoke(this, e);
        }

        /// <summary>
        /// Connect terminal to the port.
        /// </summary>
        public void ConnectTerminal(ITerminal terminal)
        {
            IncomingCallEvent += terminal.IncomingCall;
            terminal.ConnectEvent += Connect;
            terminal.DisconnectEvent += Disconnect;
            terminal.OutgoingCallEvent += OutgoingCall;
            terminal.RespondEvent += Respond;
            terminal.RejectEvent += Reject;
            Terminal = terminal;
        }

        /// <summary>
        /// Notify about incoming call.
        /// </summary>
        /// <param name="e"></param>
        public void IncomingCall(CallEventArgs e)
        {
            IncomingCallEvent?.Invoke(this, e);
        }

        private void OutgoingCall(object sender, CallEventArgs e)
        {
            e = new CallEventArgs(Id, e.TargetNumber);
            OutgoingCallEvent?.Invoke(this, e);
        }

        private void Reject(object sender, RejectEventArgs e)
        {
            RejectEvent?.Invoke(this, e);
        }

        private void Respond(object sender, RespondEventArgs e)
        {
            RespondEvent?.Invoke(this, e);
        }

    }
}