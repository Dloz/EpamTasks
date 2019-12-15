using System;
using System.Collections.Generic;
using System.Text;
using TelephoneExchangeLibrary.BillingSystem.TariffPlan;

namespace TelephoneExchangeLibrary.BillingSystem
{
    /// <summary>
    /// Represents the system which send bills to clients.
    /// </summary>
    public interface IBillingSystem
    {
        /// <summary>
        /// List of tariff plans.
        /// </summary>
        ICollection<ITariffPlan> TariffPlans { get; }
    }
}