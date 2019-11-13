using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public interface ITaxiPark
    {
        /// <summary>
        /// Represents all of cars in the Taxi Park.
        /// </summary>
        ICollection<ITaxiCar> Cars { get; set; }
        /// <summary>
        /// Represents cost of all cars.
        /// </summary>
        double Cost { get; }
        /// <summary>
        /// Search cars by speed range.
        /// </summary>
        /// <param name="from">Minimum range value.</param>
        /// <param name="to">Maximum range value.</param>
        /// <returns>Returns cars which satisfies conditions.</returns>
        IEnumerable<ICar> SearchBySpeed(int from, int to = 0);
        /// <summary>
        /// Sorting cars at the Park by Consumption value.
        /// </summary>
        void SortByConsumption();
        /// <summary>
        /// Adding cars to the park.
        /// </summary>
        /// <param name="car">Car to add.</param>
        void AddCar(ITaxiCar car);
    }
}