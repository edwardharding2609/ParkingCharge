using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingCharge
{
    class Program
    {
        static void Main(string[] args)
        {
            ICalculate parking;

            // Short term
            parking = new ShortTerm();
            // 6.6
            Console.WriteLine(parking.CalculateCost(new DateTime(2019, 10, 4, 12, 0, 0), new DateTime(2019, 10, 4, 18, 0, 0)));
            // 11
            Console.WriteLine(parking.CalculateCost(new DateTime(2019, 10, 2, 3, 0, 0), new DateTime(2019, 10, 4, 7, 0, 0)));
            // 2.2
            Console.WriteLine(parking.CalculateCost(new DateTime(2019, 10, 4, 6, 0, 0), new DateTime(2019, 10, 4, 10, 0, 0)));
            // 22
            Console.WriteLine(parking.CalculateCost(new DateTime(2019, 10, 4, 1, 0, 0), new DateTime(2019, 10, 6, 22, 0, 0)));
            // 0
            Console.WriteLine(parking.CalculateCost(new DateTime(2019, 10, 4, 1, 0, 0), new DateTime(2019, 10, 4, 3, 0, 0)));
            // 0
            Console.WriteLine(parking.CalculateCost(new DateTime(2019, 10, 4, 19, 0, 0), new DateTime(2019, 10, 5, 3, 0, 0)));
            // 29.7
            Console.WriteLine(parking.CalculateCost(new DateTime(2019, 10, 4, 1, 0, 0), new DateTime(2019, 10, 7, 15, 0, 0)));

            parking = null;

            // Long term
            parking = new LongTerm();
            // 7.5
            Console.WriteLine(parking.CalculateCost(new DateTime(2019, 10, 4, 12, 0, 0), new DateTime(2019, 10, 4, 18, 0, 0)));
            // 22.5
            Console.WriteLine(parking.CalculateCost(new DateTime(2019, 10, 2, 3, 0, 0), new DateTime(2019, 10, 4, 7, 0, 0)));
            // 7.5
            Console.WriteLine(parking.CalculateCost(new DateTime(2019, 10, 4, 6, 0, 0), new DateTime(2019, 10, 4, 10, 0, 0)));
            // 15
            Console.WriteLine(parking.CalculateCost(new DateTime(2019, 10, 4, 1, 0, 0), new DateTime(2019, 10, 5, 22, 0, 0)));
            // 7.5
            Console.WriteLine(parking.CalculateCost(new DateTime(2019, 10, 4, 1, 0, 0), new DateTime(2019, 10, 4, 3, 0, 0)));
            // 7.5
            Console.WriteLine(parking.CalculateCost(new DateTime(2019, 10, 4, 19, 0, 0), new DateTime(2019, 10, 5, 3, 0, 0)));
            // 30
            Console.WriteLine(parking.CalculateCost(new DateTime(2019, 10, 4, 1, 0, 0), new DateTime(2019, 10, 7, 15, 0, 0)));

            Console.ReadKey();
        }

    }
}
