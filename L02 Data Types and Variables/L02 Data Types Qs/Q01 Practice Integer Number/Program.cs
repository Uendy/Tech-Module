using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q01_Practice_Integer_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            //-100
            //128
            //- 3540
            //64876
            //2147483648
            //- 1141583228
            //- 1223372036854775808

            sbyte numberOne = sbyte.Parse(Console.ReadLine());
            byte numberTwo = byte.Parse(Console.ReadLine());
            short numberThree = short.Parse(Console.ReadLine());
            int numberFour = int.Parse(Console.ReadLine());
            uint numberFive = uint.Parse(Console.ReadLine());
            int numberSix = int.Parse(Console.ReadLine());
            long numberSeven = long.Parse(Console.ReadLine());

            Console.WriteLine(numberOne);
            Console.WriteLine(numberTwo);
            Console.WriteLine(numberThree);
            Console.WriteLine(numberFour);
            Console.WriteLine(numberFive);
            Console.WriteLine(numberSix);
            Console.WriteLine(numberSeven);

        }
    }
}
