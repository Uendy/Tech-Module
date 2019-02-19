using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q07_Counting_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ')
                .ToList();

            input.Sort();

            var frequencyList = new List<int>(200);
            int differentNumber = 0;

            for (int index = 0; index <= input.Count-1; index++)
            {
                bool sameNumber = input[index] == input[index + 1];

                if (sameNumber == true)
                {
                    //if (frequencyList[differentNumber] == 0)
                    if (frequencyList.Count == 0)
                    {
                        frequencyList.Insert(differentNumber, 1);
                    }
                    else
                    {
                        frequencyList[differentNumber]++;
                    }
                }
                else if (sameNumber == false)
                {
                    differentNumber++;
                    if (frequencyList.Count != 0) // see if you should do dNumber != 0
                    {
                        Console.WriteLine(input[index] + " -> " + frequencyList[differentNumber - 1]);
                    }
                }
            }

        }
    }
}
