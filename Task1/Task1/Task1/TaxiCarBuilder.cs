using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class TaxiCarBuilder
    {
        public TaxiCar TaxiCar { get; private set; }

        public TaxiCarBuilder()
        {
            TaxiCar = new TaxiCar();
        }
        public TaxiCarBuilder SetMaxSpeed(int maxSpeed)
        {
            return this;
        }

        public TaxiCarBuilder SetConsumption(double consumption)
        {
            return this;
        }

        public TaxiCarBuilder SetSeats(int numberOfSeats)
        {
            return this;
        }
        
        public static implicit operator TaxiCar(TaxiCarBuilder builder)
        {
            return builder.TaxiCar;
        }
    }
}