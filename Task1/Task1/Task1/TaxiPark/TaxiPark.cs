using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class TaxiPark : ITaxiPark
    {
        public ICollection<ITaxiCar> Cars { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}