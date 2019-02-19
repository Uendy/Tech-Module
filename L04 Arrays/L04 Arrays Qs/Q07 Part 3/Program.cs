using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q07_Part_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int currentCounter = 1;
            int oldCounter = 0;
            int sequenceStarter = 0; // array[0]

            for (int index = 1; index < array.Length; index++)
            {
                bool ascendingIntCheck = array[index] > array[index - 1];

                if (ascendingIntCheck == true)
                {
                    currentCounter++;

                    bool finalIndex = index == array.Length - 1;
                    if (finalIndex == true)
                    {
                        if (oldCounter == 0)
                        {
                            Console.WriteLine(String.Join(" ",array));
                            return;
                        }

                        bool higherCounter = currentCounter >= oldCounter;
                        if (higherCounter == true)
                        {
                            sequenceStarter = array[array.Length - currentCounter + 1];
                            int[] finallySequence = new int[currentCounter];
                            for (int i = 0; i < currentCounter; i++)
                            {
                                finallySequence[i] = array[sequenceStarter + i];
                            }

                            Console.WriteLine(String.Join(" ", finallySequence));
                            return;
                        }
                    }
                }
                else
                {
                    if (currentCounter > oldCounter)
                    {
                        oldCounter = currentCounter;
                        sequenceStarter = index - oldCounter;
                    }
                    currentCounter = 1;
                }
              
            }
            int longestCounter = Math.Max(currentCounter, oldCounter);
            int[] finalArray = new int[longestCounter];
            for (int i = 0; i <  longestCounter; i++)
            {
                finalArray[i] = array[sequenceStarter + i];
            }
            Console.WriteLine(String.Join(" ", finalArray));

        }
    }
}
