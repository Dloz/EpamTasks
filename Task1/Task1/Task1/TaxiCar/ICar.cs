using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public interface ICar
    {
        /// <summary>
        /// Vehicle identification number.
        /// </summary>
        string Vin { get; set; }
        /// <summary>
        /// The number of car seats.
        /// </summary>
        int Seats { get; set; }
        /// <summary>
        /// Engine of the car.
        /// </summary>
        IEngine Engine { get; set; }
        /// <summary>
        /// Represents current weight of the car.
        /// </summary>
        int Weight { get; set; }
        int Cost { get; set; }
        int MaxSpeed { get; }
    }
}