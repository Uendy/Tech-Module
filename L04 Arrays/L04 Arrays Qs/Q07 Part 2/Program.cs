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
            int[] array = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int currentMost = 1;
            int oldMost = 0;
            int sequenceStarter = array[0];

            for (int index = 1; index < array.Length; index++)
            {
                bool checkIfSequence = array[index] > array[index - 1];

                if (checkIfSequence == true)
                {
                    currentMost++;

                    if (index == array.Length - 1)
                    {
                        if (currentMost > oldMost)
                        {
                            sequenceStarter = array[index - currentMost]; // see if you leave the +1
                            oldMost = currentMost;
                            int[] finallySequence = new int[oldMost];
                            for (int i = 0; i < oldMost; i++)
                            {
                                finallySequence[i] = array[index - currentMost + i + 1];
                            }

                            Console.WriteLine(String.Join(" ", finallySequence));
                            return;
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
            int[] finalSequence = new int[longest];
            for (int i = 0; i < longest; i++)
            {
                finalSequence[i] = array[array.Length - longest + i]; // maybe -2  
            }

            Console.WriteLine(String.Join(" ",finalSequence));
        }
    }
}
