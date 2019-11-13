using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task1.Exceptions;

namespace Task1
{
    public class TaxiPark : ITaxiPark
    {
        /// <summary>
        /// This variable redefines Id of the Taxi Park when new Taxi Park has created.
        /// </summary>
        private static int Identifier { get; set; }
        /// <summary>
        /// Unique identifier of Taxi Park.
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// Represents all of cars in the Taxi Park
        /// </summary>
        public ICollection<ITaxiCar> Cars { get; set; } = new List<ITaxiCar>();
        /// <summary>
        /// Represents cost all of the cars.
        /// </summary>
        public double Cost {
            get {
                return Cars.Sum(c => c.Cost);
            }
        }
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
            if (Cars == null || Cars.Count == 0)
            {
                throw new EmptyParkException("Current park have no cars.");
            }
            if (to == 0)
            {
                return Cars.Where(c => c.MaxSpeed == from).Select(c => c);
            }
            return Cars.Where(c => c.MaxSpeed >= from && c.MaxSpeed <= to).Select(c => c);
        }
        /// <summary>
        /// Sorting cars at the Park by Consumption value.
        /// </summary>
        public void SortByConsumption()
        {
            if (Cars == null || Cars.Count == 0)
            {
                throw new EmptyParkException("Current park have no cars.");
            }
            var electricCars = Cars
                .Where(c => (c.Engine is ElectricEngine))
                .ToList(); // Electric engines at first positions in collection.
            var fuelCarsSorted = Cars
                .Where(c => !(c.Engine is ElectricEngine))
                .OrderBy(c => ((IConsumable)c.Engine).Consumption).ToList();
            Cars = electricCars.Concat(fuelCarsSorted).ToList();

        }
        /// <summary>
        /// Adding cars to the park.
        /// </summary>
        /// <param name="car">Car to add.</param>
        public void AddCar(ITaxiCar car)
        {
            if (car == null)
            {
                throw new NullReferenceException("This car wasn't initialized");
            }
            car.ParkId = this.Id;
            Cars.Add(car);
        }
    }
}