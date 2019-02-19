using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q02_Circle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double radius = double.Parse(Console.ReadLine());

            double area = Math.Round(Math.PI * Math.Pow(radius,2),12);

            Console.WriteLine(area);

        }
    }
}
