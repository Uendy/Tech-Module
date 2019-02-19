using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q08_Personal_Exception
{
    public class Program
    {
        static void Main(string[] args)
        {
            int currentNumber = int.Parse(Console.ReadLine());

            while (currentNumber >= 0)
            {
                Console.WriteLine(currentNumber);
                currentNumber = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("My first exception is awesome!!!"); // it really isn't and I didn't do what was asked of me!
        }
    }
}
