using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelephoneExchangeLibrary.BillingSystem;

namespace TelephoneExchangeLibrary
{
    public class Operator : IOperator
    {
        // Supposed that phone numbers are only 5-digit length
        private const int MIN_NUMBER_VALUE = 00000;
        private const int MAX_NUMBER_VALUE = 99999; //MAX_NUM
        /// <summary>
        /// Represents registered phone numbers.
        /// </summary>
        private IEnumerable<int> _registeredPhoneNumbers => Clients.SelectMany(c => c.Contracts).Select(c => c.PhoneNumber);
        public ICollection<IClient> Clients { get; }
        public IStation Station { get; }

        public IBillingSystem BillingSystem { get; }

        public ICollection<IStation> Stations { get; }

        public Operator()
        {
            Clients = new List<IClient>();
        }

        public Operator(IStation station, IBillingSystem billingSystem): this()
        {
            Station = station;
            BillingSystem = billingSystem;
        }

        public void SignContract(IClient client)
        {
            if (client == null)
            {
                throw new ArgumentException("Client is not identified.");
            }

            //Create random number
            var phoneNumber = GeneratePhoneNumber();
            //Create tariff plan
            var tariffPlan = new TariffPlan(5);

            var terminal = new Terminal();
            var port = Station.ConnectTerminal(terminal);
            var contract = new Contract(tariffPlan, this, phoneNumber, port.Id, Station.Id);
            terminal.Number = contract.PhoneNumber;

            client.ReceiveTerminal(terminal);
            client.ReceiveContract(contract);

            Clients.Add(client);
        }

        private int GeneratePhoneNumber()
        {
            var phoneNumber = new Random().Next(MIN_NUMBER_VALUE, MAX_NUMBER_VALUE);
            if (Clients.Count == 0)
            {
                return phoneNumber;
            }

            if (_registeredPhoneNumbers.Contains(phoneNumber))
            {
                return GeneratePhoneNumber();
            }

            return phoneNumber;
        }
    }
}