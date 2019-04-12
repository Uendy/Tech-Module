using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //The Anonymous have created a cyber hypervirus, which steals data from the CIA. 
        //You, as the lead security developer in CIA, have been tasked to analyze the software of the virus and observe its actions on the data.
        //The virus is known for his innovative and unbeleivably clever technique of merging and dividing data into partitions. 
        //        You will receive a single input line, containing strings, separated by spaces. 
        //The strings may contain any ASCII character except whitespace.
        //Then you will begin receiving commands in one of the following formats:
        //•	merge { startIndex} { endIndex}
        //•	divide { index} { partitions}
        //        Every time you receive the merge command, you must merge all elements from the startIndex, till the endIndex. 
        //In other words, you should concatenate them. 
        //Example: { abc, def, ghi} -> merge 0 1-> { abcdef, ghi}
        //        If any of the given indexes is out of the array, you must take only the range that is inside the array and merge it.
        //Every time you receive the divide command, you must divide the element at the given index, into several small substrings with equal length.
        //The count of the substrings should be equal to the given partitions. 
        //Example: { abcdef, ghi, jkl} -> divide 0 3-> { ab, cd, ef, ghi, jkl}
        //        If the string cannot be exactly divided into the given partitions, make all partitions except the last with equal lengths, and make the last one – the longest. 
        //Example: { abcd, efgh, ijkl} -> divide 0 3-> { a, b, cd, efgh, ijkl}
        //        The input ends when you receive the command “3:1”. At that point you must print the resulting elements, joined by a space.

        var list = Console.ReadLine().Split(' ').ToList();

        string command = Console.ReadLine();
        while (command != "3:1")
        {
            var commandTokens = command.Split(' ').ToList();
            if (commandTokens[0] == "merge")
            {
                int startIndex = int.Parse(commandTokens[1]);
                int endIndex = int.Parse(commandTokens[2]);

                if (endIndex >= list.Count())
                {
                    endIndex = list.Count() - 1;
                }

                if (startIndex < 0)
                {
                    startIndex = 0;
                }
                if (startIndex > list.Count() - 1)
                {
                    command = Console.ReadLine();
                    continue;
                }
                if (endIndex < 0)
                {
                    command = Console.ReadLine();
                    continue;
                }
                if (endIndex > list.Count() - 1)
                {
                    endIndex = list.Count() - 1;
                }

                var temporaryList = new List<string>();
                for (int index = startIndex; index <= endIndex; index++)
                {
                        temporaryList.Add(list[index]);
                }

                string mergedString = string.Concat(temporaryList);

                int range = endIndex + 1 - startIndex;
                list.RemoveRange(startIndex, range);
                list.Insert(startIndex, mergedString);
            }
            else if (commandTokens[0] == "divide")
            {
                int index = int.Parse(commandTokens[1]);
                int partisions = int.Parse(commandTokens[2]);

                var temporaryList = new List<string>();
                string currentString = list[index];

                int eachSubStringLength = currentString.Length / partisions;
                if (eachSubStringLength <= 0)
                {
                    eachSubStringLength = 1;
                    partisions = currentString.Length - 1;
                }
                int startIndex = 0;

                for (int partitionIndex = 0; partitionIndex < partisions; partitionIndex++)
                {
                    string substring = currentString.Substring(startIndex, eachSubStringLength);
                    temporaryList.Add(substring);
                    startIndex += eachSubStringLength;
                }

                if (currentString.Length % partisions != 0)
                {
                    int remainder = currentString.Length % partisions;
                    string subString = currentString.Substring(startIndex, remainder);
                    temporaryList.Add(subString);
                }

                string listDivided = string.Join(" ", temporaryList);
                list.RemoveAt(index);
                list.Insert(index, listDivided);
            }

            command = Console.ReadLine();
        }

        string outPut = string.Join(" ", list);
        Console.WriteLine(outPut);
    }
}