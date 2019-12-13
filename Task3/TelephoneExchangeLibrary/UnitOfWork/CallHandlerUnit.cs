using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelephoneExchangeLibrary.EventsArgs;

namespace TelephoneExchangeLibrary.UnitOfWork
{
    class CallHandlerUnit : UnitOfWork, ICallHandlerUnit
    {
        public void HandleAnswer(RespondEventArgs respondEventArgs)
        {

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
                return;
            }

            var targetPort = station.Ports.First(p => p.Id == targetContract.PortId);

            targetPort.IncomingCall(e);

        }

        

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
