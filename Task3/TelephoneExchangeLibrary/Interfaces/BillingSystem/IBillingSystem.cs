using System.Collections.Generic;
using TelephoneExchangeLibrary.Interfaces.TariffPlan;

namespace TelephoneExchangeLibrary.Interfaces.BillingSystem
{
    /// <summary>
    /// Represents the system which send bills to clients.
    /// </summary>
    public interface IBillingSystem
    {
        /// <summary>
        /// List of tariff plans.
        /// </summary>
        IEnumerable<ITariffPlan> TariffPlans { get; }
    }
}