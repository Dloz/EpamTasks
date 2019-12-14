using System;
using System.Collections.Generic;
using System.Text;
using TelephoneExchangeLibrary.CallRecord;

namespace TelephoneExchangeLibrary
{
    public class Contract : IContract
    {
        public ITariffPlan TariffPlan { get; }

        public IOperator Operator { get; }

        public int PhoneNumber { get; }

        public Guid Id { get; }

        public Guid PortId { get; }
        public Guid StationId { get; }

        public ICollection<ICallRecord> CallHistory { get; }

        public Contract()
        {
            CallHistory = new List<ICallRecord>();
        }

        public Contract(ITariffPlan tariffPlan, IOperator telephoneOperator, int phoneNumber, Guid portId, Guid stationId): this()
        {
            Id = Guid.NewGuid();
            TariffPlan = tariffPlan;
            Operator = telephoneOperator;
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