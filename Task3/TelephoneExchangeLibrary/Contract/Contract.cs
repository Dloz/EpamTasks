using System;
using System.Collections.Generic;
using TelephoneExchangeLibrary.BillingSystem.TariffPlan;
using TelephoneExchangeLibrary.CallRecord;
using TelephoneExchangeLibrary.Operator;

namespace TelephoneExchangeLibrary.Contract
{
    public class Contract : IContract
    {
        /// <summary>
        /// Represents tariff plan was chosen.
        /// </summary>
        public ITariffPlan TariffPlan { get; }

        /// <summary>
        /// Represents phone number.
        /// </summary>
        public int PhoneNumber { get; }
        
        /// <summary>
        /// Contract identifier.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Represents port identifier.
        /// </summary>
        public Guid PortId { get; }
        
        /// <summary>
        /// Represents station identifier.
        /// </summary>
        public Guid StationId { get; }
        
        /// <summary>
        /// Represents collection of call records.
        /// </summary>
        public ICollection<ICallRecord> CallHistory { get; }

        private Contract()
        {
            CallHistory = new List<ICallRecord>();
        }

        public Contract(ITariffPlan tariffPlan, IOperator telephoneOperator, int phoneNumber, Guid portId, Guid stationId): this()
        {
            Id = Guid.NewGuid();
            TariffPlan = tariffPlan;
            PhoneNumber = phoneNumber;
            PortId = portId;
            StationId = stationId;
        }

        public override string ToString()
        {
            return $"Number: {PhoneNumber}, Calls: {CallHistory.Count}";
        }
    }
}