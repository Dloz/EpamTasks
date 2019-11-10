using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class Engine : IEngine, IConsumable
    {
        public int Power { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Consumption { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}