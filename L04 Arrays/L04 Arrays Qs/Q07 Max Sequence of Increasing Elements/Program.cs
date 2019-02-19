using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q07_Max_Sequence_of_Increasing_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            // its not +1 its increasing !!! 
            double[] array = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            int currentMost = 1;
            int oldMost = 0;
            double sequenceStarter = array[0];

            for (int index = 1; index < array.Length; index++)
            {
                bool checkIfSequence = array[index] == array[index - 1] + 1;
               
                if (checkIfSequence == true)
                {
                    currentMost++;

                    if (index == array.Length - 1)
                    {
                        if (currentMost > oldMost)
                        {
                            sequenceStarter = array[index - currentMost + 1];
                            oldMost = currentMost;
                        }
                    }
                }
                else
                {
                    if (currentMost > oldMost)
                    {
                        oldMost = currentMost;
                        sequenceStarter = array[index - oldMost];
                    }
                    currentMost = 1;
                }
            }

            int longest = Math.Max(currentMost, oldMost);
            string output = "";
            for (int i = 0; i < longest; i++)
            {
                output += sequenceStarter++ + " ";
            }

            Console.WriteLine(output.TrimEnd());
        }
    }
}
