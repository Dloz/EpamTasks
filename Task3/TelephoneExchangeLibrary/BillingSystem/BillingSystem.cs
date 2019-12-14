using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary.BillingSystem
{
    public class BillingSystem : IBillingSystem
    {
        public ICollection<ITariffPlan> TariffPlans { get; }

        public BillingSystem()
        {
            TariffPlans = new List<ITariffPlan>();
        }

        public BillingSystem(ICollection<ITariffPlan> tariffPlans)
        {
            TariffPlans = tariffPlans;
        }
    }
}
