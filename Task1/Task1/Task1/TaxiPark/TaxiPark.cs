using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{
    public class TaxiPark : ITaxiPark
    {
        /// <summary>
        /// Unique identifier of Taxi Park.
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// Represents all of cars in the Taxi Park
        /// </summary>
        public ICollection<ICar> Cars { get; set; }
        /// <summary>
        /// Represents cost all of the cars.
        /// </summary>
        public double Cost {
            get {
                return Cars.Sum(c => c.Cost);
            }
        }
        /// <summary>
        /// Search cars by speed range.
        /// </summary>
        /// <param name="from">Minimum range value.</param>
        /// <param name="to">Maximum range value.</param>
        /// <returns>Returns cars which satisfies conditions.</returns>
        public IEnumerable<ICar> SearchBySpeed(int from, int to = 0)
        {
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
            try
            {
                Cars.OrderBy(c => ((IConsumable)c.Engine).Consumption); // TODO: Check how it works with electric engines
            }
            catch
            {
                // Ignoring inappropriate cast from ElectricEngine to IConsumable.
                // Because the idea that ElectricEngine doesn't consume fuel.
            }
        }
    }
}