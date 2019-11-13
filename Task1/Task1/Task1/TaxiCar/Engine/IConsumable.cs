using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public interface IConsumable
    {
        /// <summary>
        /// Represents consumption of fuel per 100km.
        /// </summary>
        double Consumption { get; }
    }
}