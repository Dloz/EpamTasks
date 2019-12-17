using System.Collections.Generic;
using TelephoneExchangeLibrary.Interfaces.BillingSystem;
using TelephoneExchangeLibrary.Interfaces.TariffPlan;

namespace TelephoneExchangeLibrary.Models.BillingSystem
{
    /// <summary>
    /// Represents the system which send bills to clients.
    /// </summary>
    public class BillingSystemModel : IBillingSystem
    {
        private readonly ICollection<ITariffPlan> _tariffPlans;

        /// <summary>
        /// List of tariff plans.
        /// </summary>
        public IEnumerable<ITariffPlan> TariffPlans => _tariffPlans;

        public BillingSystemModel(ICollection<ITariffPlan> tariffPlans)
        {
            _tariffPlans = tariffPlans;
        }
    }
}
