using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q07_Sum_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] firstArray = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();


            int[] secondArray = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();


            string output = "";

            switch (firstArray.Length >= secondArray.Length)
            {
                case true:

                    switch (firstArray.Length > secondArray.Length)
                    {
                        case true:// First>Second

                            int[] firstFinal = new int[firstArray.Length];
                            int firstDifference = firstArray.Length - secondArray.Length;

                            for (int i = 0; i < firstArray.Length; i++)
                            {
                                bool secondStillCycling = i < secondArray.Length;

                                if (secondStillCycling == true)
                                {
                                    firstFinal[i] = firstArray[i] + secondArray[i];
                                    output += firstFinal[i] + " ";
                                }
                                else
                                {
                                    int secondCycleNumbers = i / secondArray.Length; // this bit I am super proud of !!!
                                    firstFinal[i] = firstArray[i] + secondArray[i - secondArray.Length * secondCycleNumbers];
                                    output += firstFinal[i] + " ";
                                }
                            }
                            break;

                        case false: // ==
                            int[] evenFinal = new int[firstArray.Length];

                            for (int i = 0; i < firstArray.Length; i++)
                            {
                                evenFinal[i] = firstArray[i] + secondArray[i];
                                output += evenFinal[i] + " ";
                            }

                            break;
                    }

                    break;

                case false: //first < second
                    int[] secondFinal = new int[secondArray.Length];
                    int secondDifference = secondArray.Length - firstArray.Length;
                    

                    for (int i = 0; i < secondArray.Length; i++)
                    {
                        bool firstStillCycling = i < firstArray.Length;

                        if (firstStillCycling == true)
                        {
                            secondFinal[i] = secondArray[i] + firstArray[i];
                            output += secondFinal[i] + " ";
                        }
                        else
                        {
                            int firstCycleNumber = i / firstArray.Length;
                            secondFinal[i] = secondArray[i] + firstArray[i - firstArray.Length * firstCycleNumber];
                            output += secondFinal[i] + " ";
                        }

                    }
                    break;
            }

            Console.WriteLine(output.TrimEnd());
        }
    }
}
