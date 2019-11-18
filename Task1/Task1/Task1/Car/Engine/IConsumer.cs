namespace Task1Library.Car.Engine
{
    public interface IConsumer
    {
        /// <summary>
        /// Represents consumption of fuel per 100km.
        /// </summary>
        double Consumption { get; }
    }
}