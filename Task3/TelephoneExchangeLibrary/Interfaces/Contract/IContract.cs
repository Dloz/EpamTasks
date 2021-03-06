﻿using System;
using System.Collections.Generic;
using TelephoneExchangeLibrary.Interfaces.CallRecord;
using TelephoneExchangeLibrary.Interfaces.TariffPlan;

namespace TelephoneExchangeLibrary.Interfaces.Contract
{
    public interface IContract: IIdentifiable
    {
        /// <summary>
        /// Represents port identifier.
        /// </summary>
        Guid PortId { get; }
        
        /// <summary>
        /// Represents station identifier.
        /// </summary>
        Guid StationId { get; }
        // Balance
        
        /// <summary>
        /// Represents collection of call records.
        /// </summary>
        ICollection<ICallRecord> CallHistory { get; }
        
        /// <summary>
        /// Represents tariff plan was chosen.
        /// </summary>
        ITariffPlan TariffPlan { get; }
        
        /// <summary>
        /// Represents phone number.
        /// </summary>
        int PhoneNumber { get; }
    }
}