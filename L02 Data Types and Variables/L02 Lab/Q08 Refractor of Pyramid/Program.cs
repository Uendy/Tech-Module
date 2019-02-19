using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q08_Refractor_of_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Length: ");
            double lengthSize = double.Parse(Console.ReadLine());

            Console.Write("Width: ");
            double widthSize = double.Parse(Console.ReadLine());

            Console.Write("Height: ");
             double heightSize = double.Parse(Console.ReadLine());

            double Volume = (lengthSize * widthSize * heightSize) / 3;
            Console.WriteLine("Pyramid Volume: {0:F2}", Volume);

        }
    }
}
