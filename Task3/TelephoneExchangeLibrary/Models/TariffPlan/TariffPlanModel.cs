using TelephoneExchangeLibrary.Interfaces.TariffPlan;

namespace TelephoneExchangeLibrary.Models.TariffPlan
{
    /// <summary>
    /// Represents tariff plan of the operator.
    /// </summary>
    public class TariffPlanModel : ITariffPlan
    {
        /// <summary>
        /// Represents cost of call per minute.
        /// </summary>
        public int Cost { get; }

        public TariffPlanModel(int cost)
        {
            Cost = cost;
        }
    }
}