namespace Task1Library.Car.Engine
{
    public class ElectricEngine : IEngine, IConsumer
    {
        /// <summary>
        /// Represents amount of horse power
        /// </summary>
        public int Power { get; }
        /// <summary>
        /// Represents consumption of battery energy per 100km.
        /// </summary>
        public double Consumption { get; }
        public ElectricEngine(int power, double consumption)
        {
            Power = power;
            Consumption = consumption;
        }

    }
}