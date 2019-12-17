namespace TelephoneExchangeLibrary.Models.TariffPlan
{
    public class StandartTariffPlanModel: TariffPlanModel
    {
        private const int costPerMinute = 5;
        /// <summary>
        /// Create new instance of tariff plan with specified cost;
        /// </summary>
        public StandartTariffPlanModel(): base(costPerMinute)
        {

        }
    }
}
