using Task1Library.Car.Engine;

namespace Task1Library.Car
{
    public interface ICar
    {
        /// <summary>
        /// Vehicle identification number.
        /// </summary>
        string Vin { get; }
        /// <summary>
        /// The number of car seats.
        /// </summary>
        int Seats { get; }
        /// <summary>
        /// Engine of the car.
        /// </summary>
        IEngine Engine { get; }
        /// <summary>
        /// Represents current weight of the car.
        /// </summary>
        double Weight { get; }
        /// <summary>
        /// Represents cost of the car in dollars.
        /// </summary>
        decimal Cost { get; }
        /// <summary>
        /// Represents maximum reachable speed of the car.
        /// </summary>
        double MaxSpeed { get; }
    }
}