using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchangeLibrary
{
    public class Operator : IOperator
    {
        // Supposed that phone numbers are only 5-digit length
        private const int minNumberValue = 00000;
        private const int maxNumberValue = 99999; //MAX_NUM
        /// <summary>
        /// Represents registered phone numbers.
        /// </summary>
        private IEnumerable<int> _registeredPhoneNumbers => Clients.SelectMany(c => c.Contracts).Select(c => c.PhoneNumber);
        public ICollection<IClient> Clients { get; }
        public IStation Station { get; }

        public IBillingSystem BillingSystem { get; }

        public ICollection<IStation> Stations { get; }

        public Operator(IStation station)
        {
            Station = station;
        }

        public void SignContract(IClient client)
        {
            //Create random number
            var phoneNumber = GeneratePhoneNumber();
            //Create tariff plan
            var tariffPlan = new TariffPlan(5);

            var contract = new Contract(tariffPlan, this, phoneNumber);
            var terminal = new Terminal();
            Station.ConnectTerminal(terminal);

            client.ReceiveTerminal(terminal);
            client.ReceiveContract(contract);
        }

        private int GeneratePhoneNumber()
        {
            var phoneNumber = new Random().Next(minNumberValue, maxNumberValue);
            if (_registeredPhoneNumbers.Contains(phoneNumber))
            {
                return GeneratePhoneNumber();
            }
            return phoneNumber;
        }
    }
}