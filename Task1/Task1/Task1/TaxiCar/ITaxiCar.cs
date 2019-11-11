using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public interface ITaxiCar
    {
        /// <summary>
        /// Identification number of Taxi Park which owns the car.
        /// </summary>
        int Id { get; set; }
    }
}