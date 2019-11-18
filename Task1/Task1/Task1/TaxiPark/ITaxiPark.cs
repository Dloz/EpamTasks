using System.Collections.Generic;
using Task1Library.Car;

namespace Task1Library.TaxiPark
{
    /// <summary>
    /// Represents interface of Taxi Park.
    /// </summary>
    public interface ITaxiPark
    {
        /// <summary>
        /// Unique identifier of Taxi Park.
        /// </summary>
        int Id { get; }
        /// <summary>
        /// Represents of all cars at the Taxi Park.
        /// </summary>
        ICollection<ITaxiCar> Cars { get; set; }
        /// <summary>
        /// Represents cost of all cars.
        /// </summary>
        decimal Cost { get; }
        /// <summary>
        /// Searches cars by speed range.
        /// </summary>
        /// <param name="from">Minimum range value.</param>
        /// <param name="to">Maximum range value.</param>
        /// <returns>Returns cars which satisfies conditions.</returns>
        IEnumerable<ICar> SearchBySpeed(int from, int to = 0);
        /// <summary>
        /// Searches cars with specific speed value.
        /// </summary>
        /// <param name="speed">Specific speed value.</param>
        /// <returns>Returns cars which satisfies conditions.</returns>
        IEnumerable<ICar> SearchBySpeed(int speed);
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