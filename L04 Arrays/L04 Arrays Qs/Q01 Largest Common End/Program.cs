using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q01_Largest_Common_End
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string[] secondArray = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int similair = 0;
            int oldSimilair = 0;

            for (int firstSpin = 0; firstSpin < firstArray.Length; firstSpin++)
            {
                string firstCheckedString = firstArray[firstSpin];

                for (int secondSpin = 0; secondSpin < secondArray.Length; secondSpin++)
                {
                    string secondCheckedString = secondArray[secondSpin];

                    if (similair > 0)
                    {
                        if (firstCheckedString != secondCheckedString)
                        {
                            oldSimilair += similair;
                            similair = 0;
                        }
                    }

                    if (firstCheckedString == secondCheckedString)
                    {
                        similair++;
                        break;
                    }
                }

            }

            Console.WriteLine(Math.Max(similair, oldSimilair));
        }
    }
}
