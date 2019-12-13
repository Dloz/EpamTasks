using System;
using System.Collections.Generic;
using System.Text;
using TelephoneExchangeLibrary.CallRecord;

namespace TelephoneExchangeLibrary
{
    public interface IContract: IIdentifiable
    {
        // PortId
        Guid PortId { get; }
        // StationId
        Guid StationId { get; }
        // Balance
        // CallHistory
        ICollection<ICallRecord> CallHistory { get; }
        ITariffPlan TariffPlan { get; }
        // delete: IOperator Operator { get; }
        int PhoneNumber { get; }
    }
}