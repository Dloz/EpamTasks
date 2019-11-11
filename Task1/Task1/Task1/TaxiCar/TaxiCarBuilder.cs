using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class TaxiCarBuilder
    {
        private TaxiCar taxiCar;

        public TaxiCarBuilder()
        {
            taxiCar = new TaxiCar();
            taxiCar.Vin = new Guid().ToString();
        }
        /// <summary>
        /// Constructs the seats of the car.
        /// </summary>
        /// <param name="numberOfSeats">Number of seats</param>
        /// <returns></returns>
        public TaxiCarBuilder SetSeats(int numberOfSeats)
        {
            return this;
        }
        /// <summary>
        /// Constructs engine of the car.
        /// </summary>
        /// <param name="engine">Engine.</param>
        /// <returns></returns>
        public TaxiCarBuilder SetEngine(IEngine engine)
        {
            taxiCar.Engine = engine;
            return this;
        }
        /// <summary>
        /// Add information about car weight.
        /// </summary>
        /// <param name="weight">Weight.</param>
        /// <returns></returns>
        public TaxiCarBuilder SetWeight(int weight)
        {
            taxiCar.Weight = weight;
            return this;
        }
        /// <summary>
        /// Contstructs cost of the car.
        /// </summary>
        /// <param name="cost">Cost.</param>
        /// <returns></returns>
        public TaxiCarBuilder SetCost(int cost)
        {
            taxiCar.Cost = cost;
            return this;
        }
        public static implicit operator TaxiCar(TaxiCarBuilder builder)
        {
            return builder.taxiCar;
        }


    }
}