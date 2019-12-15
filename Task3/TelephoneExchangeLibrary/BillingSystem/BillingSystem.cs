using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelephoneExchangeLibrary.BillingSystem.TariffPlan;
using TelephoneExchangeLibrary.UnitOfWork;

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
        public IEnumerable<ITariffPlan> TariffPlans => _tariffPlans.AsEnumerable();

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
