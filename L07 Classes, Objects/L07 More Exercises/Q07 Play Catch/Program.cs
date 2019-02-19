using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q07_Play_Catch
{
    class Program
    {
        static void Main(string[] args)
        {
            var initialArray = Console.ReadLine().Split(' ').ToArray();
            var legitArray = new List<int>();
            foreach (var number in initialArray)
            {
                legitArray.Add(int.Parse(number));
            }

            int exceptions = 0;

            while (exceptions < 3)
            {
                var input = Console.ReadLine().Split().ToArray();

                switch (input[0])
                {
                    case "Replace":

                        bool succesfullyParsed = Int32.TryParse(input[1], out int index);
                        if (succesfullyParsed == true)
                        {
                            bool succesfullyParsedTwo = Int32.TryParse(input[2], out int element);
                            if (succesfullyParsedTwo == true)
                            {
                                bool arrayContainsIndex = legitArray.Count + 1 > index;
                                if (arrayContainsIndex == true)
                                {
                                    legitArray[index] = element;
                                }
                                else
                                {
                                    Console.WriteLine("The index does not exist!");
                                    exceptions++;
                                }
                            }
                            else
                            {
                                Console.WriteLine("The variable is not in the correct format!");
                                exceptions++;
                            }
                        }
                        else
                        {
                            Console.WriteLine("The variable is not in the correct format!");
                            exceptions++;
                        }
                        break;

                    case "Print":
                        bool successfullyParsed = Int32.TryParse(input[1], out int initialIndex);
                        if (successfullyParsed == true)
                        {
                            bool successfullyParsedTwo = Int32.TryParse(input[2], out int endIndex);
                            if (successfullyParsedTwo == true)
                            {
                                var initialIndexExists = legitArray.ElementAtOrDefault(initialIndex) != 0;
                                var endIndexExists = legitArray.ElementAtOrDefault(endIndex) != 0;
                                bool bothIndexExist = initialIndexExists && endIndexExists;
                                if (bothIndexExist == true)
                                {
                                    StringBuilder sb = new StringBuilder();
                                    for (int indexOfSearch = initialIndex; indexOfSearch < endIndex+ 1; indexOfSearch++)
                                    {
                                        if (indexOfSearch == endIndex)
                                        {
                                            sb.Append(legitArray[indexOfSearch]);
                                            continue;
                                        }
                                        sb.Append(legitArray[indexOfSearch]).Append(", ");
                                    }
                                    Console.WriteLine(sb);
                                }
                                else
                                {
                                    Console.WriteLine("The index does not exist!");
                                    exceptions++;
                                }
                            }
                            else
                            {
                                Console.WriteLine("The variable is not in the correct format!");
                                exceptions++;
                            }
                        }
                        else
                        {
                            Console.WriteLine("The variable is not in the correct format!");
                            exceptions++;
                        }
                        break;

                    case "Show":
                        bool successfullyParsedShow = Int32.TryParse(input[1], out int indexToShow);
                        if (successfullyParsedShow == true)
                        {
                            var numberAtIndex = legitArray.ElementAtOrDefault(indexToShow) != 0;
                            if (numberAtIndex == true)
                            {
                                Console.WriteLine(legitArray[indexToShow]);
                            }
                            else
                            {
                                Console.WriteLine("The index does not exist!");
                                exceptions++;
                            }
                        }
                        else
                        {
                            Console.WriteLine("The variable is not in the correct format!");
                            exceptions++;
                        }
                        break;
                }
            }

            StringBuilder finalSB = new StringBuilder();
            for (int indexOfFinalArray = 0; indexOfFinalArray < legitArray.Count; indexOfFinalArray++)
            {
                if (indexOfFinalArray == legitArray.Count - 1)
                {
                    finalSB.Append(legitArray[indexOfFinalArray]);
                    continue;
                }
                finalSB.Append(legitArray[indexOfFinalArray]).Append(", ");
            }
            Console.WriteLine(finalSB);

        }
    }
}
