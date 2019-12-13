using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelephoneExchangeLibrary.EventsArgs;
using TelephoneExchangeLibrary.CallRecord;

namespace TelephoneExchangeLibrary.UnitOfWork
{
    class CallHandlerUnit : UnitOfWork, ICallHandlerUnit
    {
        /// <summary>
        /// Reperents connections at the moment of time as callerNumber, targetNumber, CallId
        /// </summary>
        private IList<ConnectionModel> connections;

        public CallHandlerUnit()
        {
            connections = new List<ConnectionModel>();
        }
        public void HandleAnswer(RespondEventArgs e)
        {
            var currentConnection = connections.FirstOrDefault(c => c.Id == e.Id);
            
            if (currentConnection == null)
            {
                return;
            }

            IContract callerContract = phoneOperator.Clients
                .SelectMany(c => c.Contracts)
                .First(c => c.PhoneNumber == currentConnection.CallerNumber);

            IContract targetContract = phoneOperator.Clients
                .SelectMany(c => c.Contracts)
                .First(c => c.PhoneNumber == currentConnection.TargetNumber);

            ICallRecord callRecord = new CallRecord.CallRecord(callerContract.PhoneNumber,
                                                                targetContract.PhoneNumber,
                                                                DateTime.Now);

            callerContract.CallHistory.Add(callRecord);

            station.Ports.First(p => p.Id == callerContract.PortId);

        }

        public void HandleCall(CallEventArgs e)
        {
            IContract callerContract = phoneOperator.Clients
                .SelectMany(c => c.Contracts)
                .First(c => c.PortId == e.PortId);
            
            IContract targetContract = phoneOperator.Clients
                .SelectMany(c => c.Contracts)
                .First(c => c.PhoneNumber == e.TargetNumber);

            if (!CanCallStarted(callerContract, targetContract))
            {
                return;// TODO specify the exception
            }

            connections.Add(new ConnectionModel(callerContract.PhoneNumber, targetContract.PhoneNumber, e.Id));
            var targetPort = station.Ports.First(p => p.Id == targetContract.PortId);

            targetPort.IncomingCall(e);

        }

        
        /// <summary>
        /// Represents set of reasons why a call can or can't be started.
        /// </summary>
        private bool CanCallStarted(IContract callerContract, IContract targetContract)
        {
            if (callerContract.StationId != targetContract.StationId)
            {
                return false;
                //throw new Exception(""); // TODO specify the exception
            }
            if (callerContract.PhoneNumber == targetContract.PhoneNumber)
            {
                return false;
            }
            return true;
        }
    }
}
