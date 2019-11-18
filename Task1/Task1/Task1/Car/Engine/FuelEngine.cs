namespace Task1Library.Car.Engine
{
    public class FuelEngine : IEngine, IConsumer
    {
        /// <summary>
        /// Represents amount of horse power
        /// </summary>
        public int Power { get; private set; }
        /// <summary>
        /// Represents consumption of fuel per 100km.
        /// </summary>
        public double Consumption { get; private set; }
        public FuelEngine(int power, double consumption)
        {
            Power = power;
            Consumption = consumption;
        }
    }
}