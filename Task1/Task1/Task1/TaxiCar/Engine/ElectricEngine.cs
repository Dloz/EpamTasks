using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class ElectricEngine : IEngine
    {
        /// <summary>
        /// Represents Amount Of Horse Power
        /// </summary>
        public int Power { get; private set; }
        /// <summary>
        /// Represents Amount Of Miles Engine Can Pass.
        /// </summary>
        public int Miles { get; private set; }

        public ElectricEngine(int power, int miles)
        {
            Power = power;
            Miles = miles;
        }
    }
}