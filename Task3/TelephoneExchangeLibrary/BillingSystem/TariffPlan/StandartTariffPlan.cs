using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary.BillingSystem.TariffPlan
{
    public class StandartTariffPlan: TariffPlan
    {
        private const int costPerMinute = 5;
        /// <summary>
        /// Create new instance of tariff plan with specified cost;
        /// </summary>
        public StandartTariffPlan(): base(costPerMinute)
        {

        }
    }
}
