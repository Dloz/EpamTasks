using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using SalesInfoService.BLL;

namespace SalesInfoService.Presentation.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var facade = new Facade();
            
            facade.Run();

            Console.WriteLine("Press any key to stop...");
            Console.ReadKey();
            
            facade.Stop();
        }
    }
}
