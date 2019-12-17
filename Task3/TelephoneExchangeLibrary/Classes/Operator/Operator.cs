using System;
using System.Collections.Generic;
using System.Linq;
using TelephoneExchangeLibrary.Interfaces.BillingSystem;
using TelephoneExchangeLibrary.Interfaces.CallReport;
using TelephoneExchangeLibrary.Interfaces.Client;
using TelephoneExchangeLibrary.Interfaces.Contract;
using TelephoneExchangeLibrary.Interfaces.Operator;
using TelephoneExchangeLibrary.Interfaces.Reporter;
using TelephoneExchangeLibrary.Interfaces.Station;
using TelephoneExchangeLibrary.Interfaces.TariffPlan;
using TelephoneExchangeLibrary.Interfaces.Terminal;
using TelephoneExchangeLibrary.Models.Client;
using TelephoneExchangeLibrary.Models.Contract;

namespace TelephoneExchangeLibrary.Classes.Operator
{
    public class Operator : IOperator
    {
        private readonly IReporterService _reporter;
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

        public Operator(ICollection<IStation> stations, IBillingSystem billingSystem, IReporterService reporter): this()
        {
            _reporter = reporter;
            Stations = stations;
            BillingSystem = billingSystem;
        }

        public ValueTuple<IContract, ITerminal> SignContract(ITariffPlan tariffPlan, IClient client = null) // TODO clientId optional parameter and return contract with terminal.
        {
            var output = new ValueTuple<IContract, ITerminal>();

            if (client == null) // TODO Register client
            {
                client = new ClientModel();
                Clients.Add(client);
            }

            // Create random number
            var phoneNumber = GeneratePhoneNumber();
            // Register user at random station.
            var station = Stations.ToList()[new Random().Next(0, Stations.Count - 1)];

            var terminal = new Terminal.Terminal();
            var port = station.ConnectTerminal(terminal);
            port.ConnectTerminal(terminal);
            station.AddPort(port);
            
            var contract = new ContractModel(tariffPlan, this, phoneNumber, port.Id, station.Id);
            terminal.Number = contract.PhoneNumber;
            
            Clients.Add(client);

            output.Item1 = contract;
            output.Item2 = terminal;

            return output;
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