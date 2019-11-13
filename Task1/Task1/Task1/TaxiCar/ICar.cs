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
        string Vin { get; }
        /// <summary>
        /// The number of car seats.
        /// </summary>
        int Seats { get; }
        /// <summary>
        /// Engine of the car.
        /// </summary>
        IEngine Engine { get; }
        /// <summary>
        /// Represents current weight of the car.
        /// </summary>
        int Weight { get; }
        /// <summary>
        /// Represents cost of the car in dollars.
        /// </summary>
        int Cost { get; }
        /// <summary>
        /// Represents maximum reachable speed of the car.
        /// </summary>
        int MaxSpeed { get; }
    }
}