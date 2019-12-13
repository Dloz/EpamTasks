using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary
{
    public interface IBillingSystem
    {
        ICollection<ITariffPlan> TariffPlans { get; }
    }
}