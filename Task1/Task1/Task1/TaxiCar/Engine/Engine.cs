using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class Engine : IEngine, IConsumable
    {
        /// <summary>
        /// Represents Amount Of Horse Power
        /// </summary>
        public int Power { get; private set; }
        /// <summary>
        /// Represents consumption of fuel per 100km.
        /// </summary>
        public double Consumption { get; private set; }

        public Engine(int power, double consumption)
        {
            Power = power;
            Consumption = consumption;
        }
    }
}