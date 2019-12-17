using System;
using System.Collections.Generic;
using System.Linq;
using TelephoneExchangeLibrary.Enums.Port;
using TelephoneExchangeLibrary.EventsArgs;
using TelephoneExchangeLibrary.Interfaces.CallHandler;
using TelephoneExchangeLibrary.Interfaces.CallRecord;
using TelephoneExchangeLibrary.Interfaces.Contract;
using TelephoneExchangeLibrary.Models.CallRecord;
using TelephoneExchangeLibrary.Models.Connection;

namespace TelephoneExchangeLibrary.Services.CallHandler
{
    public class CallHandlerService : Service, ICallHandlerUnit //
    {
        /// <summary>
        /// Represents connections at the moment of time as callerNumber, targetNumber, CallId
        /// </summary>
        private readonly IList<ConnectionModel> _connections;

        public CallHandlerService()
        {
            _connections = new List<ConnectionModel>();
        }
        public void HandleRespond(RespondEventArgs e)
        {
            var currentConnection = _connections.FirstOrDefault(c => c.TargetNumber == e.ResponderNumber);
            
            if (currentConnection == null)
            {
                return;
            }

            var callerContract = PhoneOperator.Clients
                .SelectMany(c => c.Contracts)
                .First(c => c.PhoneNumber == currentConnection.CallerNumber);

            var targetContract = PhoneOperator.Clients
                .SelectMany(c => c.Contracts)
                .First(c => c.PhoneNumber == currentConnection.TargetNumber);

            ICallRecord callRecord = new CallRecordModel(callerContract.PhoneNumber,
                                                                targetContract.PhoneNumber,
                                                                DateTime.Now,
                                                                currentConnection.Id);

            callerContract.CallHistory.Add(callRecord);
            targetContract.CallHistory.Add(callRecord);
        }

        public void HandleCall(CallEventArgs e)
        {
            var callerContract = PhoneOperator.Clients
                .SelectMany(c => c.Contracts)
                .First(c => c.PortId == e.PortId);
            
            var targetContract = PhoneOperator.Clients
                .SelectMany(c => c.Contracts)
                .First(c => c.PhoneNumber == e.TargetNumber);

            if (!CanCallStarted(callerContract, targetContract))
            {
                return; 
            }

            _connections.Add(new ConnectionModel(callerContract.PhoneNumber, targetContract.PhoneNumber, e.Id));
            var targetPort = Station.Ports.First(p => p.Id == targetContract.PortId);

            if (targetPort.Status != PortStatus.Connected)
            {
                return; // Cannot handle connection.
            }

            targetPort.IncomingCall(e);

        }

        public void HandleReject(RejectEventArgs e)
        {
            var currentConnection = _connections.FirstOrDefault(c => c.TargetNumber == e.CallerNumber);

            if (currentConnection == null)
            {
                return;
            }

            var callerContract = PhoneOperator.Clients
                .SelectMany(c => c.Contracts)
                .First(c => c.PhoneNumber == currentConnection.CallerNumber);

            var targetContract = PhoneOperator.Clients
                .SelectMany(c => c.Contracts)
                .First(c => c.PhoneNumber == currentConnection.TargetNumber);

            targetContract.CallHistory.First(c => c.TargetNumber == currentConnection.TargetNumber).EndedAt = DateTime.Now;
            callerContract.CallHistory.First(c => c.CallerNumber == currentConnection.CallerNumber).EndedAt = DateTime.Now;

            _connections.Remove(currentConnection);
        }


        /// <summary>
        /// Represents set of reasons why a call can or can't be started.
        /// </summary>
        private bool CanCallStarted(IContract callerContract, IContract targetContract)
        {
            // If user calls another user which registered in another station
            if (callerContract.StationId != targetContract.StationId)
            {
                return false;
            }
            // If user tries to call himself.
            if (callerContract.PhoneNumber == targetContract.PhoneNumber)
            {
                return false;
            }
            return true;
        }
    }
}
