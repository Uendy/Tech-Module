using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q12_Rectangle_Properties
{
    class Program
    {
        static void Main(string[] args)
        {
           double length = double.Parse(Console.ReadLine());
           double width = double.Parse(Console.ReadLine());

            double perimeter = length * 2 + width * 2;
            double area = length * width;
            double diagonal = Math.Sqrt(Math.Pow(length, 2) + Math.Pow(width, 2));

            Console.WriteLine(perimeter);
            Console.WriteLine(area);
            Console.WriteLine(diagonal);
        }
    }
}
