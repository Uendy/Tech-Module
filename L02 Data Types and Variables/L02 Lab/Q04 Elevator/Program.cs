using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q04_Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPassangers = int.Parse(Console.ReadLine());
            int singleCapacity = int.Parse(Console.ReadLine());

            double rides = (double)numberOfPassangers / singleCapacity;

            Console.WriteLine(Math.Ceiling(rides));
        }
    }
}
