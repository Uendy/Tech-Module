using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q05_Calculate_Triangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(TriangleArea());
        }

        static double TriangleArea()
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            return width * 0.5 * height;
        }
    }
}
