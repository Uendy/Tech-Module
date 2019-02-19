using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q05_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

             bool keepReading = true;
             while (keepReading == true)
             {
                var instructions = Console.ReadLine()
                .Split(' ')
                .ToArray();

                    
                switch (instructions[0])
                {
                    case "print":
                        keepReading = false;
                        Console.WriteLine("[" + String.Join(", ",input) + "]");
                        break;

                    case "add":
                        int index = Convert.ToInt32(instructions[1]);
                        int element = Convert.ToInt32(instructions[2]);
                        input.Insert(index, element);
                        break;

                    case "addMany":
                        int indexOfAddMany = Convert.ToInt32(instructions[1]);
                        
                        var additions = new List <int>();
                        for (int currentIndex = 2; currentIndex < instructions.Length; currentIndex++)
                        {
                            int elementOfAddMany = Convert.ToInt32(instructions[currentIndex]);
                            additions.Insert(currentIndex - 2, elementOfAddMany);
                        }
                        additions.Reverse();

                        for (int indexOfAdditions = 0; indexOfAdditions < additions.Count; indexOfAdditions++)
                        {
                            input.Insert(indexOfAddMany, additions[indexOfAdditions]);
                        }
                        break;

                    case "contains":
                        int containsSearch = Convert.ToInt32(instructions[1]);
                        if (input.Contains(containsSearch) == true)
                        {
                            for (int indexForContains = 0; indexForContains < input.Count; indexForContains++)
                            {
                                if (input[indexForContains] == containsSearch)
                                {
                                    Console.WriteLine(indexForContains);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine(-1);
                        }
                        break;

                    case "remove":
                        int removeIndexAt = Convert.ToInt32(instructions[1]);
                        input.RemoveAt(removeIndexAt);
                        break;

                    case "shift":
                        int shiftBy = Convert.ToInt32(instructions[1]);
                        var temporaryList = new List <int>(input);

                        for (int oldIndex = 0; oldIndex < temporaryList.Count; oldIndex++)
                        {
                            input[oldIndex] = temporaryList[((oldIndex + shiftBy) % input.Count)]; //% sameIndex.Length];
                        }
                        
                        break;

                    case "sumPairs":
                        var temporaryPairList = new List<int>();
                        if (input.Count % 2 == 0) // even
                        {
                            for (int pairIndex = 0; pairIndex < input.Count; pairIndex += 2)
                            {
                                temporaryPairList.Insert(pairIndex / 2, input[pairIndex] + input[pairIndex + 1]);
                            }
                        }
                        else // odd
                        {
                            for (int pairIndex = 0; pairIndex < input.Count-1; pairIndex += 2)
                            {
                                temporaryPairList.Insert(pairIndex / 2, input[pairIndex] + input[pairIndex + 1]);
                            }
                            temporaryPairList.Insert(temporaryPairList.Count, input[input.Count-1]);
                        }
                            input = temporaryPairList;

                        break;
                }

             }
        }
    }
}
