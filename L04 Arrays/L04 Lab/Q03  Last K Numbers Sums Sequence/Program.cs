using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q03__Last_K_Numbers_Sums_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());
            int amountOfNumbersAddedUp = int.Parse(Console.ReadLine());

      
            int[] afterAdditionArray = new int[numberOfInputs];

            
            afterAdditionArray[0] = 1;

            for (int turn = 1; turn < numberOfInputs; turn++)
            {
                int start = Math.Max(0, turn - amountOfNumbersAddedUp);
                for (int i = start; i < turn; i++)
                {
                    afterAdditionArray[turn] += afterAdditionArray[i];
                }
            }
          
            string finalOutput = "";
            for (int cell = 0; cell < numberOfInputs; cell++)
            {
                finalOutput += afterAdditionArray[cell] + " ";
            }

            Console.WriteLine(finalOutput.TrimEnd());
        }
    }
}
