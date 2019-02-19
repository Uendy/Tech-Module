using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q071
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputData = Console.ReadLine();

            if (inputData == "int")
            {
                int firstInput = int.Parse(Console.ReadLine());
                int secondInput = int.Parse(Console.ReadLine());
            }
            else
            {
                var firstInput = Console.ReadLine();
                var secondInput = Console.ReadLine();
            }

            Console.WriteLine(Print(2,16));
        }

        static int Print(int firstInput, int secondInput)
        {
           
            
            if (firstInput >= secondInput)
            {
                return firstInput;
            }
            else
            {
                return secondInput;
            }
        }

        static string Print(string firstInput, string secondInput)
        {
            if (firstInput.CompareTo(secondInput) > 0)
            {
                return firstInput;
            }
            else
            {
                return secondInput;
            }
        }

        static char Print(char firstInput, char secondInput)
        {
            if (firstInput > secondInput)
            {
                return firstInput;
            }
            else
            {
                return secondInput;
            }
        }
    }
}
