using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary
{
    public class TariffPlan : ITariffPlan
    {
        public int Cost { get; }

        public TariffPlan(int cost)
        {
            Cost = cost;
        }
    }
}