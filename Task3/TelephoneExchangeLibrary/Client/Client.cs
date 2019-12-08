using System;
using System.Collections.Generic;
using System.Text;
using TelephoneExchangeLibrary.EventsArgs;

namespace TelephoneExchangeLibrary
{
    public class Client : IClient
    {
        public ITerminal Terminal { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICollection<IContract> Contracts { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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