using System;
using System.Collections.Generic;
using System.Linq;
using Task1Library.Car;
using Task1Library.Car.Engine;
using Task1Library.Exceptions;

namespace Task1Library.TaxiPark
{
    public class TaxiPark : ITaxiPark
    {
        private readonly string _nonInitializedErrorMessage = "This car wasn't initialized";
        private readonly string _haveNoCarsErrorMessage = "Current park have no cars.";
        /// <summary>
        /// This variable redefines Id of the Taxi Park when new Taxi Park has created.
        /// </summary>
        private static int Identifier { get; set; }
        /// <summary>
        /// Unique identifier of Taxi Park.
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// Represents of all cars at the Taxi Park
        /// </summary>
        public ICollection<ITaxiCar> Cars { get; set; } = new List<ITaxiCar>();
        /// <summary>
        /// Represents cost of all cars.
        /// </summary>
        public decimal Cost => Cars.Sum(c => c.Cost);
        public TaxiPark()
        {
            Id = Identifier;
            Identifier++;
        }
        public TaxiPark(ICollection<ITaxiCar> cars): this()
        {
            Cars = cars;
        }
        /// <summary>
        /// Search cars by speed range.
        /// </summary>
        /// <param name="from">Minimum range value.</param>
        /// <param name="to">Maximum range value. Optional.</param>
        /// <returns>Returns cars which satisfies conditions.</returns>
        public IEnumerable<ICar> SearchBySpeed(int from, int to = 0)
        {
            if (to <= 0) throw new ArgumentOutOfRangeException(nameof(to));
            if (Cars == null || Cars.Count == 0)
            {
                throw new EmptyParkException(_haveNoCarsErrorMessage);
            }
            if (to == 0)
            {
                return Cars.Where(c => c.MaxSpeed >= from);
            }
            return Cars.Where(c => c.MaxSpeed >= from && c.MaxSpeed <= to);
        }
        /// <summary>
        /// Searches cars with specific speed value.
        /// </summary>
        /// <param name="speed">Specific speed value.</param>
        /// <returns>Returns cars which satisfies conditions.</returns>
        public IEnumerable<ICar> SearchBySpeed(int speed)
        {
            if (Cars == null || Cars.Count == 0)
            {
                throw new EmptyParkException(_haveNoCarsErrorMessage);
            }
            return Cars.Where(c => c.MaxSpeed == speed);
        }
        /// <summary>
        /// Sorting cars at the Park by Consumption value.
        /// </summary>
        public void SortByConsumption()
        {
            if (Cars == null || Cars.Count == 0)
            {
                throw new EmptyParkException(_haveNoCarsErrorMessage);
            }
//            var electricCars = Cars
//                .Where(c => (c.Engine is ElectricEngine))
//                .ToList(); // Electric engines at first positions in collection.
//            var fuelCarsSorted = Cars
//                .Where(c => !(c.Engine is ElectricEngine))
//                .OrderBy(c => ((IConsumer)c.Engine).Consumption).ToList();
//            Cars = electricCars.Concat(fuelCarsSorted).ToList();
            Cars = Cars.OrderBy(c => ((IConsumer)c.Engine).Consumption).ToList();

        }
        /// <summary>
        /// Adding cars to the park.
        /// </summary>
        /// <param name="car">Car to add.</param>
        public void AddCar(ITaxiCar car)
        {
            if (car == null)
            {
                throw new NullReferenceException(message: _nonInitializedErrorMessage);
            }
            car.ParkId = this.Id;
            Cars.Add(car);
        }


    }
}