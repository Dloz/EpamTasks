using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelephoneExchangeLibrary.EventsArgs;
using TelephoneExchangeLibrary.CallRecord;

namespace TelephoneExchangeLibrary.UnitOfWork
{
    public class CallHandlerUnit : UnitOfWork, ICallHandlerUnit
    {
        /// <summary>
        /// Reperents connections at the moment of time as callerNumber, targetNumber, CallId
        /// </summary>
        private IList<ConnectionModel> connections;

        public CallHandlerUnit()
        {
            connections = new List<ConnectionModel>();
        }
        public void HandleRespond(RespondEventArgs e)
        {
            var currentConnection = connections.FirstOrDefault(c => c.TargetNumber == e.ResponderNumber); // identify by id
            
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
                                                                DateTime.Now,
                                                                currentConnection.Id);

            callerContract.CallHistory.Add(callRecord);
            targetContract.CallHistory.Add(callRecord);
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

        public void HandleReject(RejectEventArgs e)
        {
            var currentConnection = connections.FirstOrDefault(c => c.CallerNumber == e.CallerNumber);

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

            

            targetContract.CallHistory.First(c => c.Id == currentConnection.Id).EndCall(DateTime.Now);
            callerContract.CallHistory.First(c => c.Id == currentConnection.Id).EndCall(DateTime.Now);
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
