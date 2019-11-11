using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public interface ITaxiPark
    {
        /// <summary>
        /// Represents all of cars in the Taxi Park
        /// </summary>
        ICollection<ICar> Cars { get; set; }
        /// <summary>
        /// Represents cost all of the cars.
        /// </summary>
        double Cost { get; }
        /// <summary>
        /// Search cars by speed range.
        /// </summary>
        /// <param name="from">Minimum range value.</param>
        /// <param name="to">Maximum range value.</param>
        /// <returns>Returns cars which satisfies conditions.</returns>
        IEnumerable<ICar> SearchBySpeed(int from, int to = 0);
    }
}