using System;
using System.Linq;
using System.Threading;
using TelephoneExchangeLibrary;
using TelephoneExchangeLibrary.BillingSystem;
using TelephoneExchangeLibrary.Client;
using TelephoneExchangeLibrary.Operator;
using TelephoneExchangeLibrary.Station;
using TelephoneExchangeLibrary.UnitOfWork;

namespace TelephoneExchangeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var callHandler = new CallHandlerUnit();
            IBillingSystem billingSystem = new BillingSystem();
            IStation station = new Station(callHandler);
            IOperator phoneOperator = new Operator(station, billingSystem);


            callHandler.RegisterStation(station);
            callHandler.RegisterBillingSystem(billingSystem);
            callHandler.RegisterOperator(phoneOperator);


            IClient client1 = new Client();
            IClient client2 = new Client();

            phoneOperator.SignContract(client1);
            phoneOperator.SignContract(client2);

            client1.Call(client2.Contracts.First().PhoneNumber);

            client2.Respond();
            Thread.Sleep(1000);

            client1.Reject();
        }
    }
}
