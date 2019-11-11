using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class TaxiCar : ITaxiCar, ICar
    {
        /// <summary>
        /// Vehicle identification number.
        /// </summary>
        public string Vin { get; set; }
        /// <summary>
        /// Represents maximum reachable speed of the car.
        /// </summary>
        public int MaxSpeed 
        {
            get {
                return Engine.Power * 100 / Weight; // Magic formula to imitate variability of MaxSpeed.
            }
        }
        /// <summary>
        /// Identification number of Taxi Park which owns the car.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The number of car seats.
        /// </summary>
        public int Seats { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        /// <summary>
        /// Engine of the car.
        /// </summary>
        public IEngine Engine { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        /// <summary>
        /// Represents current weight of the car.
        /// </summary>
        public int Weight { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        /// <summary>
        /// Represents cost of the car.
        /// </summary>
        public int Cost { get; set; }
    }
}