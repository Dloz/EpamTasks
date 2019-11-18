namespace Task1Library.Car
{
    public interface ITaxiCar: ICar
    {
        /// <summary>
        /// Identification number of Taxi Park which owns the car.
        /// </summary>
        int ParkId { get; set; }
    }
}