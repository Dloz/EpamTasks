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
        int Vin { get; set; }
        /// <summary>
        /// Maximum reachable speed.
        /// </summary>
        int MaxSpeed { get; set; }
        /// <summary>
        /// The amount of fuel car consumes for 100km.
        /// </summary>
        double Consumption { get; set; }
        int Seats { get; set; }
    }
}