namespace TelephoneExchangeLibrary.BillingSystem.TariffPlan
{
    /// <summary>
    /// Represents tariff plan of the operator.
    /// </summary>
    public class TariffPlan : ITariffPlan
    {
        /// <summary>
        /// Represents cost of call per minute.
        /// </summary>
        public int Cost { get; }

        public TariffPlan(int cost)
        {
            Cost = cost;
        }
    }
}