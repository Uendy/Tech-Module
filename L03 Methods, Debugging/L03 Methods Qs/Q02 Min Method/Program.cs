using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q02_Min_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            NumberReader();
        }

        static void NumberReader()
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            GetMax(firstNumber, secondNumber, thirdNumber);
        }

        static void GetMax(int firstNumber, int secondNumber, int thirdNumber)
        {
            if (firstNumber >= secondNumber && firstNumber >= thirdNumber)
            {
                Console.WriteLine(firstNumber);
            }
            else if (secondNumber >= firstNumber && secondNumber >= thirdNumber)
            {
                Console.WriteLine(secondNumber);
            }
            else
            {
                Console.WriteLine(thirdNumber);
            }
        }
    }
}
