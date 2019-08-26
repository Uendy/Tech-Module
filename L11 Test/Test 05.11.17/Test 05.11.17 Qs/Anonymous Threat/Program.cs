using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Program
{
    public static void Main()
    {
        #region
        //The Anonymous have created a cyber hypervirus which steals data from the CIA. 
        //You, as the lead security developer in CIA, 
        //have been tasked to analyze the software of the virus and observe its actions on the data.
        //The virus is known for his innovative and unbeleivably clever technique of merging and dividing data into partitions. 

        //You will receive a single input line containing STRINGS separated by spaces. 
        //The strings may contain any ASCII character except whitespace.
        //You will then begin receiving commands in one of the following formats:

        //•	merge { startIndex} { endIndex}
        //•	divide { index} { partitions}

        //Every time you receive the merge command, you must merge all elements from the startIndex, till the endIndex. 
        //In other words, you should concatenate them. 
        //Example: { abc, def, ghi} -> merge 0 1-> { abcdef, ghi}
        //If any of the given indexes is out of the array, you must take ONLY the range that is INSIDE the array and merge it.
        //Every time you receive the divide command, you must DIVIDE the element at the given index,
        //into several small substrings with equal length.The count of the substrings should be equal to the given partitions. 
        //Example: { abcdef, ghi, jkl} -> divide 0 3-> { ab, cd, ef, ghi, jkl}
        //If the string CANNOT be exactly divided into the given partitions, make all partitions except the LAST with EQUAL LENGTHS,
        //and make the LAST one – the LONGEST. 
        //Example: { abcd, efgh, ijkl} -> divide 0 3-> { a, b, cd, efgh, ijkl}

        //The input ends when you receive the command “3:1”. At that point you must print the resulting elements, joined by a space.

        //Input
        //•	The first input line will contain the array of data.
        //•	On the next several input lines you will receive commands in the format specified above.
        //•	The input ends when you receive the command “3:1”.

        //Output
        //•	As output you must print a single line containing the elements of the array, joined by a space.

        //Constrains
        //•	The strings in the array may contain any ASCII character except whitespace.
        //•	The startIndex and the endIndex will be in range[-1000, 1000].
        //•	The endIndex will ALWAYS be GREATER than the startIndex.
        //•	The index in the divide command will ALWAYS be INSIDE the array.
        //•	The partitions will be in range[0, 100].
        //•	Allowed working time / memory: 100ms / 16MB.
       #endregion

        string input = Console.ReadLine();

        bool isEmpty = string.IsNullOrEmpty(input);
        if (isEmpty)
        {
            Console.WriteLine(input);
            Environment.Exit(0);
        }

        var inputTokens = input.Split(' ').ToArray();
        var tokens = new List<string>(inputTokens);

        string command = Console.ReadLine();
        while (command != "3:1")
        {
            var commandTokens = command.Split(' ').ToArray();
            string acutalCommand = commandTokens[0];

            if (acutalCommand == "merge")
            {
                int startIndex = int.Parse(commandTokens[1]);
                int endIndex = int.Parse(commandTokens[2]);

                bool negativeIndex = startIndex < 0 || endIndex < 0;
                if (negativeIndex)
                {
                    command = Console.ReadLine();
                    continue;
                }

                //checking if end index is above cut off and if so bringing it down to the max
                bool afterFinalIndex = endIndex > tokens.Count();
                if (afterFinalIndex)
                {
                    endIndex = tokens.Count() - 1;
                }

                // putting all substrings in a massive string then removing all substring from tokens to return it as a single value
                var sb = new StringBuilder();
                for (int index = startIndex; index <= endIndex; index++)
                {
                    string currentString = tokens[index];
                    sb.Append(currentString);
                }

                int lengthBetweenIndexs = endIndex - startIndex + 1; 

                tokens.RemoveRange(startIndex, lengthBetweenIndexs);
                tokens.Insert(startIndex, sb.ToString());
            }
            else // divide method
            {
                int index = int.Parse(commandTokens[1]);
                int partitions = int.Parse(commandTokens[2]);

                string currentString = tokens[index];
                var asCharArray = currentString.ToCharArray();
                int arraySize = asCharArray.Count();

                var listOfSubStrings = new List<string>();

                int partitionSize = arraySize / partitions;

                var currentSubstring = string.Empty;

                for (int innerIndex = 0; innerIndex < arraySize; innerIndex += partitionSize)
                {
                    bool finalIndex = listOfSubStrings.Count() == partitions - 1;// 11-> 3/3/3 then the final one 
                    if (finalIndex)
                    {
                        bool evenSplit = arraySize % partitions == 0;
                        if (evenSplit)
                        {
                            currentSubstring = currentString.Substring(innerIndex, partitionSize);
                        }
                        else // not an even split so last part has itself + remainder
                        {
                            var remainder = arraySize % partitions;
                            currentSubstring = currentString.Substring(innerIndex, partitionSize + remainder);
                            innerIndex += remainder;
                        }
                    }
                    else
                    {
                        currentSubstring = currentString.Substring(innerIndex, partitionSize);
                    }
                    listOfSubStrings.Add(currentSubstring);
                    currentSubstring = string.Empty;
                } 

                tokens.RemoveAt(index);
                tokens.InsertRange(index, listOfSubStrings);
            }

            command = Console.ReadLine();
        }

        string output = string.Join(" ", tokens);
        Console.WriteLine(output);
    }
}