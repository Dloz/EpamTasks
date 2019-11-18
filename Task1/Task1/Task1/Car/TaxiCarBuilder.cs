using Task1Library.Car.Engine;

namespace Task1Library.Car
{
    public class TaxiCarBuilder
    {
        private readonly TaxiCar _taxiCar;

        public TaxiCarBuilder()
        {
            _taxiCar = new TaxiCar();
        }
        /// <summary>
        /// Constructs the seats of the car.
        /// </summary>
        /// <param name="numberOfSeats">Number of seats</param>
        /// <returns></returns>
        public TaxiCarBuilder SetSeats(int numberOfSeats)
        {
            _taxiCar.Seats = numberOfSeats;
            return this;
        }
        /// <summary>
        /// Constructs engine of the car.
        /// </summary>
        /// <param name="engine">Engine.</param>
        /// <returns></returns>
        public TaxiCarBuilder SetEngine(IEngine engine)
        {
            _taxiCar.Engine = engine;
            return this;
        }
        /// <summary>
        /// Add information about car weight.
        /// </summary>
        /// <param name="weight">Weight.</param>
        /// <returns></returns>
        public TaxiCarBuilder SetWeight(int weight)
        {
            _taxiCar.Weight = weight;
            return this;
        }
        /// <summary>
        /// Constructs cost of the car.
        /// </summary>
        /// <param name="cost">Cost.</param>
        /// <returns></returns>
        public TaxiCarBuilder SetCost(int cost)
        {
            _taxiCar.Cost = cost;
            return this;
        }
        public static implicit operator TaxiCar(TaxiCarBuilder builder)
        {
            return builder._taxiCar;
        }


    }
}