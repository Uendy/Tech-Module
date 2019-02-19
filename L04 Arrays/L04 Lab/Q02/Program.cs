using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q02
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());

            string reversedLine = "";

            int[] arrayOfReversedNumber = new int[numberOfInputs];

            for (int turn = numberOfInputs - 1; turn >= 0; turn--)
            {
                arrayOfReversedNumber[turn] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < numberOfInputs; i++)
            {
                reversedLine += arrayOfReversedNumber[i] + " "; 
            }

            Console.WriteLine(reversedLine.TrimEnd());

        }
    }
}
