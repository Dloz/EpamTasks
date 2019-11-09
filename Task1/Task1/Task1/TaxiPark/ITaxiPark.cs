using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public interface ITaxiPark
    {
        ICollection<ITaxiCar> Cars { get; set; }
    }
}