using System;
using System.Collections.Generic;
using System.Linq;
using TelephoneExchangeLibrary.BillingSystem;
using TelephoneExchangeLibrary.BillingSystem.TariffPlan;
using TelephoneExchangeLibrary.Client;
using TelephoneExchangeLibrary.Station;
using TelephoneExchangeLibrary.UnitOfWork;
using TelephoneExchangeLibrary.UnitOfWork.Reporter;
using TelephoneExchangeLibrary.UnitOfWork.Reporter.CallReport;

namespace TelephoneExchangeLibrary.Operator
{
    public class Operator : IOperator
    {
        private readonly IReporterUnit _reporter;
        // Supposed that phone numbers are only 5-digit length
        private const int MinNumberValue = 00000;
        private const int MaxNumberValue = 99999; 
        /// <summary>
        /// Represents registered phone numbers.
        /// </summary>
        private IEnumerable<int> RegisteredPhoneNumbers => Clients.SelectMany(c => c.Contracts).Select(c => c.PhoneNumber);
        
        /// <summary>
        /// Represents registered clients.
        /// </summary>
        public ICollection<IClient> Clients { get; }
        public IStation Station { get; }

        /// <summary>
        /// Represents billing system connected to the operator.
        /// </summary>
        public IBillingSystem BillingSystem { get; }

        /// <summary>
        /// Represents collection of station.
        /// </summary>
        public ICollection<IStation> Stations { get; }

        private Operator()
        {
            Clients = new List<IClient>();
        }

        public Operator(IStation station, IBillingSystem billingSystem, IReporterUnit reporter): this()
        {
            _reporter = reporter;
            Station = station;
            BillingSystem = billingSystem;
        }

        public void SignContract(IClient client, ITariffPlan tariffPlan)
        {
            if (client == null)
            {
                throw new ArgumentException("Client is not identified.");
            }

            //Create random number
            var phoneNumber = GeneratePhoneNumber();

            var terminal = new Terminal.Terminal();
            var port = Station.ConnectTerminal(terminal);
            var contract = new Contract.Contract(tariffPlan, this, phoneNumber, port.Id, Station.Id);
            terminal.Number = contract.PhoneNumber;

            client.ReceiveTerminal(terminal);
            client.ReceiveContract(contract);

            Clients.Add(client);
        }

        public void SignContract(IClient client)
        {
            //Create basic tariff plan
            var tariffPlan = new StandartTariffPlan();
            
            SignContract(client, tariffPlan);
        }

        public ICollection<ICallReport> GetReport(IClient client)
        {
            return _reporter.GetReport(client);
        }

        /// <summary>
        /// Generate unique phone number.
        /// </summary>
        /// <returns>unique phone number.</returns>
        private int GeneratePhoneNumber()
        {
            while (true)
            {
                var phoneNumber = new Random().Next(MinNumberValue, MaxNumberValue);
                if (Clients.Count == 0)
                {
                    return phoneNumber;
                }
                // If number exists - generate new one.
                if (RegisteredPhoneNumbers.Contains(phoneNumber))
                {
                    continue;
                }

                return phoneNumber;
            }
        }
    }
}