using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q04_Variable_in_Hex_Format
{
    class Program
    {
        static void Main(string[] args)
        {
            //0xFE
            //0x37
            //0x10

            string numberOne = Console.ReadLine();
            int decimalNumberOne = Convert.ToInt32(numberOne, 16);
            string binaryNumberOne = Convert.ToString(Convert.ToInt32(numberOne, 16),2);

            //string numberTwo = Console.ReadLine();
            //int decimalNumberTwo = Convert.ToInt32(numberTwo, 16);

            //string numberThree = Console.ReadLine();
            //int decimalNumberThree = Convert.ToInt32(numberThree, 16);

            Console.WriteLine(decimalNumberOne);
            Console.WriteLine(binaryNumberOne);
            //Console.WriteLine(decimalNumberTwo);
            //Console.WriteLine(decimalNumberThree);

            string binaryInput = Console.ReadLine();

            int hexadecimal = Convert.ToInt32(binaryInput,2);
            Console.WriteLine(hexadecimal);
        }
    }
}
