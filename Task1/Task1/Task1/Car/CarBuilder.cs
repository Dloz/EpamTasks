using Task1Library.Car.Engine;

namespace Task1Library.Car
{
    public class CarBuilder
    {
        private readonly Car _car;

        public CarBuilder()
        {
            _car = new Car();
        }
        /// <summary>
        /// Constructs the seats of the car.
        /// </summary>
        /// <param name="numberOfSeats">Number of seats</param>
        /// <returns></returns>
        public CarBuilder SetSeats(int numberOfSeats)
        {
            _car.Seats = numberOfSeats;
            return this;
        }
        /// <summary>
        /// Constructs engine of the car.
        /// </summary>
        /// <param name="engine">Engine.</param>
        /// <returns></returns>
        public CarBuilder SetEngine(IEngine engine)
        {
            _car.Engine = engine;
            return this;
        }
        /// <summary>
        /// Add information about car weight.
        /// </summary>
        /// <param name="weight">Weight.</param>
        /// <returns></returns>
        public CarBuilder SetWeight(int weight)
        {
            _car.Weight = weight;
            return this;
        }
        /// <summary>
        /// Constructs cost of the car.
        /// </summary>
        /// <param name="cost">Cost.</param>
        /// <returns></returns>
        public CarBuilder SetCost(int cost)
        {
            _car.Cost = cost;
            return this;
        }
        public static implicit operator Car(CarBuilder builder)
        {
            return builder._car;
        }

    }
}