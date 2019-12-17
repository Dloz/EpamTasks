namespace TelephoneExchangeLibrary.Interfaces.TariffPlan
{
    /// <summary>
    /// Represents tariff plan of the operator.
    /// </summary>
    public interface ITariffPlan
    {
        /// <summary>
        /// Represents cost of call per minute.
        /// </summary>
        int Cost { get; }
    }
}