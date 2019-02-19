using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q07_Attempt_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            input.Sort();
            int sameNumber = 1;

            for (int index = 0; index <= input.Count-1; index++)
            {
                if (index == input.Count - 1)
                {
                    Console.WriteLine(input[index] + " -> " + sameNumber);
                    return;
                }

                bool sameNumberAgain = input[index] == input[index + 1]; 

                if (sameNumberAgain == true)
                {
                    sameNumber++;
                }
                else
                {
                        Console.WriteLine(input[index] + " -> " + sameNumber);
                        sameNumber = 1;
                }
            }

        }

    }
}
