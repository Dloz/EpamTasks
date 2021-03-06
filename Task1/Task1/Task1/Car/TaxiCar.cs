﻿using System;
using Task1Library.Car.Engine;

namespace Task1Library.Car
{
    public class TaxiCar : ITaxiCar
    {
        /// <summary>
        /// Vehicle identification number.
        /// </summary>
        public string Vin { get; }
        /// <summary>
        /// Represents maximum reachable speed of the car.
        /// </summary>
        public int MaxSpeed => (int)(Engine.Power * 1000 / Weight); // Magic formula to imitate variability of the speed.

        /// <summary>
        /// Identification number of Taxi Park which owns the car.
        /// </summary>
        public int ParkId { get; set; }
        /// <summary>
        /// The number of car seats.
        /// </summary>
        public int Seats { get; set; }
        /// <summary>
        /// Engine of the car.
        /// </summary>
        public IEngine Engine { get; set; }
        /// <summary>
        /// Represents current weight of the car.
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Represents cost of the car in dollars.
        /// </summary>
        public decimal Cost { get; set; }

        public TaxiCar()
        {
            Vin = Guid.NewGuid().ToString();
        }
        public override string ToString()
        {
            return $"Car - {Vin}\nParkId - {ParkId}\nMaxSpeed - {MaxSpeed}\nConsumption - {((IConsumer)Engine).Consumption}\n";
        }
    }
}