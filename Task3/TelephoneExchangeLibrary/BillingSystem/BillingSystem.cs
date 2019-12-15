using System;
using System.Collections.Generic;
using System.Text;
using TelephoneExchangeLibrary.BillingSystem.TariffPlan;

namespace TelephoneExchangeLibrary.BillingSystem
{
    /// <summary>
    /// Represents the system which send bills to clients.
    /// </summary>
    public class BillingSystem : IBillingSystem
    {
        private readonly ICollection<ITariffPlan> _tariffPlans;

        /// <summary>
        /// List of tariff plans.
        /// </summary>
        public ICollection<ITariffPlan> TariffPlans => _tariffPlans;

        public BillingSystem()
        {
            _tariffPlans = new List<ITariffPlan>();
        }

        public BillingSystem(ICollection<ITariffPlan> tariffPlans): this()
        {
            _tariffPlans = tariffPlans;
        }
    }
}
