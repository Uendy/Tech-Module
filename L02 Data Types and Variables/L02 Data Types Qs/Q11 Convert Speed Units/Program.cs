using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q11_Convert_Speed_Units
{
    class Program
    {
        static void Main(string[] args)
        {
            
            float distanceTravelled = float.Parse(Console.ReadLine());


            float hoursTaken = float.Parse(Console.ReadLine());
            float minutesTaken = float.Parse(Console.ReadLine());
            float secondsTaken = float.Parse(Console.ReadLine());

            float totalSeconds = secondsTaken + minutesTaken * 60 + hoursTaken * 3600; //whole time converted 
            float metersPerSeconds = distanceTravelled / totalSeconds;
            Console.WriteLine(metersPerSeconds);

            float totalHours = secondsTaken / 3600 + minutesTaken / 60 + hoursTaken;
            float kiloMetersTravelled = distanceTravelled / 1000;                                 //km/h
            float kilometersPerHour = kiloMetersTravelled / totalHours;
            Console.WriteLine(kilometersPerHour);

            float milesTravelled = distanceTravelled / 1609;
            float milesPerHour = milesTravelled / totalHours; //mph
            Console.WriteLine(milesPerHour);

        }
    }
}
