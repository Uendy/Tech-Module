using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //the question is written out in Q02 Anonymour Threat (V1)

        string input = Console.ReadLine();

        bool emptyOrNull = string.IsNullOrEmpty(input);
        if (emptyOrNull)
        {
            Console.WriteLine(input);
            return;
        }

        var inputTokens = input.Split(' ').ToArray();
        var tokens = new List<string>(inputTokens);

        string commandInput = Console.ReadLine().ToLower();

        while (commandInput != "3:1")
        {
            var commandTokens = commandInput.Split(' ').ToArray();

            string command = commandTokens[0];
            if (command == "merge")
            {
                tokens = MergeTokens(tokens, commandTokens);
            }
            else if (command == "divide")
            {
                tokens = DivideToken(tokens, commandTokens);
            }

            commandInput = Console.ReadLine();
        }

        //when command is "3:1" print out the tokens 
        string outPut = string.Join(" ", tokens);
        Console.WriteLine(outPut);
    }

    //method to check and if needed correct the indexs
    public static int IndexCheck(int index, int maxLength)
    {
        bool startTooSoon = index < 0;
        if (startTooSoon)
        {
            index = 0;
        }

        bool overMax = index >= maxLength;
        if (overMax)
        {
            index = maxLength - 1;
        }

        return index;
    }

    //Method to merge string[] from the startIndex to the endIndex
    public static List<string> MergeTokens(List<string> tokens, string[] commandTokens)
    {
        int maxLength = tokens.Count();

        int startIndex = int.Parse(commandTokens[1]);
        int endIndex = int.Parse(commandTokens[2]);

        //checking indexs
        startIndex = IndexCheck(startIndex, maxLength);
        endIndex = IndexCheck(endIndex, maxLength);

        //getting the new merged string
        int lengthBetweenIndexs = endIndex - startIndex + 1;

        var rangeOfString = tokens.GetRange(startIndex, lengthBetweenIndexs).ToArray();
        string mergedString = string.Join("", rangeOfString);

        //substituting old string[]s for the new merged one that contains them all
        tokens.RemoveRange(startIndex, lengthBetweenIndexs);
        tokens.Insert(startIndex, mergedString);

        return tokens;
    }

    //Method to divide a string from tokens (string[]) into partitions and insert them back into tokens
    public static List<string> DivideToken(List<string> tokens, string[] commandTokens)
    {
        int startIndex = int.Parse(commandTokens[1]); // index will always be in the array
        int partitions = int.Parse(commandTokens[2]);

        string currentString = tokens[startIndex];
        var asArray = currentString.ToCharArray().ToList();
        int currentStringLength = currentString.Length;
        int partitionSize = currentStringLength / partitions;

        var listOfNewSubstrings = new List<string>();

        for (int indexOfPartition = 0; indexOfPartition < partitions; indexOfPartition++)
        {
            bool lastPartition = indexOfPartition == partitions - 1;
            bool notEvenPartitions = currentStringLength % partitions != 0; // so this one gets the remaining elements;

            if (lastPartition && notEvenPartitions)
            {
                var oddSubString = string.Join("", asArray);
                listOfNewSubstrings.Add(oddSubString);
            }
            else //taking the regular partition size, making it into a new string and adding it to listOfNewSubstring
            {
                var currentSubstringAsArray = asArray.Take(partitionSize).ToArray();
                var currentSubstring = string.Join("", currentSubstringAsArray);
                listOfNewSubstrings.Add(currentSubstring);

                //removing already used elements of the currentStringAsArray
                asArray.RemoveRange(0, partitionSize);
            }
        }

        // removing the string at the start index and inserting the range of new substring from list
        tokens.RemoveAt(startIndex);
        tokens.InsertRange(startIndex, listOfNewSubstrings);

        return tokens;
    }
}