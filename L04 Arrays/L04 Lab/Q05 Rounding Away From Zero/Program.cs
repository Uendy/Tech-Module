using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q05_Rounding_Away_From_Zero
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arrayOfInputs = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            for (int index = 0; index <= arrayOfInputs.Length - 1; index++)
            {

                Console.Write($"{arrayOfInputs[index]}");
                arrayOfInputs[index] = Math.Round(arrayOfInputs[index], MidpointRounding.AwayFromZero);
                Console.WriteLine($" => {arrayOfInputs[index]}");
            }

        }
    }
}
