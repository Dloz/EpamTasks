using System;
using Task1Library.Car;
using Task1Library.Car.Engine;
using Task1Library.TaxiPark;

namespace Task1Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create 2 taxi parks.
            ITaxiPark taxiPark1 = new TaxiPark();
            ITaxiPark taxiPark2 = new TaxiPark();

            // Create different engines to test.
            IEngine V6engine = new FuelEngine(242, 9.8);
            IEngine V8engine = new FuelEngine(479, 15.7);
            IEngine V12engine = new FuelEngine(987, 20.8);
            IEngine electricEngine = new ElectricEngine(256, 6.4);

            //Create cars and add them to taxi parks.
            TaxiCar taxiCar4 = new TaxiCarBuilder()
                .SetCost(6400)
                .SetEngine(V6engine)
                .SetSeats(5)
                .SetWeight(1200);
            TaxiCar taxiCar1 = new TaxiCarBuilder()
                .SetCost(6700)
                .SetEngine(V6engine)
                .SetSeats(5)
                .SetWeight(1700);
            TaxiCar taxiCar2 = new TaxiCarBuilder()
                .SetCost(16100)
                .SetEngine(V8engine)
                .SetSeats(5)
                .SetWeight(1900);
            TaxiCar taxiCar3 = new TaxiCarBuilder()
                .SetCost(26400)
                .SetEngine(V12engine)
                .SetSeats(5)
                .SetWeight(2200);
            TaxiCar electricTaxiCar = new TaxiCarBuilder()
                .SetCost(36400)
                .SetEngine(electricEngine)
                .SetSeats(5)
                .SetWeight(2000);

            taxiPark2.AddCar(taxiCar3);
            taxiPark2.AddCar(taxiCar2);
            taxiPark2.AddCar(taxiCar1);

            taxiPark2.AddCar(taxiCar4);
            taxiPark2.AddCar(electricTaxiCar);
            //Test methods.
            foreach (var item in
            taxiPark1.SearchBySpeed(100, 300))
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
            foreach (var item in
            taxiPark1.SearchBySpeed(142))
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
            //taxiPark.SortByConsumption();
            taxiPark2.SortByConsumption();
            Console.WriteLine();
        }
    }
}
