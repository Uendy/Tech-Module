using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //not my code, taken from : https://github.com/martinmladenov/SoftUni-Solutions/blob/master/Programming%20Fundamentals/Exams/PF%20Exam%20-%2005%20November%202017/02.%20Anonymous%20Threat/AnonymousThreat.cs

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

        var list = Console.ReadLine().Split();
        string input;
        while ((input = Console.ReadLine()) != "3:1")
        {
            var commandTokens = input.Split();
            switch (commandTokens[0])
            {
                case "merge":
                    list = Merge(list, int.Parse(commandTokens[1]), int.Parse(commandTokens[2]));
                    break;

                case "divide":
                    list = Divide(list, int.Parse(commandTokens[1]), int.Parse(commandTokens[2]));
                    break;
            }
        }
        Console.WriteLine(string.Join(" ", list));
    }



    private static string[] Merge(string[] line, int startIndex, int endIndex)
    {
        string merged = string.Empty;
        if (startIndex < 0)
        { startIndex = 0; }
        if (endIndex >= line.Length)
        { endIndex = line.Length - 1; }
        for (int i = startIndex; i <= endIndex; i++)
        { merged += line[i]; }

        return line.Take(startIndex)
            .Concat(new[] { merged })
            .Concat(line.Skip(endIndex + 1))
            .ToArray();
    }

    private static string[] Divide(string[] line, int index, int partitions)
    {
        string element = line[index];

        int partitionLength = element.Length / partitions;
        var divided = new string[partitions];
        for (int i = 0; element.Length > partitionLength; i++)
        {
            divided[i] = element.Substring(0, partitionLength);
            element = element.Substring(partitionLength);
        }
        divided[partitions - 1] += element;
        return line.Take(index)
            .Concat(divided)
            .Concat(line.Skip(index + 1))
            .ToArray();
    }
}