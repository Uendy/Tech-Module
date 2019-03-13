using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //The clone factory in Kamino got another order to clone troops.
        //But this time you are tasked to find the best DNA sequence to use in the production. 
        //You will receive the DNA length and until you receive the command "Clone them!"
        //you will be receiving a DNA sequences of ones and zeroes, split by "!"(one or several).
        //You should select the sequence with the longest subsequence of ones.
        //If there are several sequences with same length of subsequence of ones,
        //print the one with the leftmost starting index,
        //if there are several sequences with same length and starting index,
        //select the sequence with the greater sum of its elements.
        //After you receive the last command "Clone them!"
        //you should print the collected information in the following format:
        //"Best DNA sample {bestSequenceIndex} with sum: {bestSequenceSum}."
        //"{DNA sequence, joined by space}"

        int numberOfInputs = int.Parse(Console.ReadLine());

        var listOfStrands = new List<Strand>();

        string input = Console.ReadLine();

        while (input != "Clone them!")
        {
            var currentStrand = new Strand();
            listOfStrands.Add(currentStrand);

            var array = input
                .Split(new char[] { '!' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            currentStrand.Genome = array;
            currentStrand.Sum = array.Sum();
            currentStrand.CurrentSequence = 1;
            currentStrand.LongestSequence = 1;
            currentStrand.startIndexOfSequence = 0;

            for (int index = 0; index < array.Length - 1; index++)
            {
                if (array[index] == 0)
                {
                    continue;
                }

                for (int secondIndex = index + 1; secondIndex < array.Length; secondIndex++)
                {
                    bool isSequence = array[index] == array[secondIndex];
                    if (isSequence == true)
                    {
                        currentStrand.CurrentSequence++;
                    }
                    else
                    {
                        if (currentStrand.CurrentSequence > currentStrand.LongestSequence)
                        {
                            currentStrand.LongestSequence = currentStrand.CurrentSequence;
                            currentStrand.startIndexOfSequence = index;
                        }
                        currentStrand.CurrentSequence = 1;
                        break;
                    }
                }
            }
            input = Console.ReadLine();
        }

        int indexOfGenome = 0;
        int recordSequence = 0;
        int indexOfSeq = 0;
        int sum = 0;
        int[] bestGenome = new int[input.Length];

        for (int index = 0; index < listOfStrands.Count(); index++)
        {
            var currentGenome = listOfStrands[index];

            if (currentGenome.LongestSequence > recordSequence) //You should select the sequence with the longest subsequence of ones. 
            {
                indexOfGenome = index;
                recordSequence = currentGenome.LongestSequence;
                indexOfSeq = currentGenome.startIndexOfSequence;
                sum = currentGenome.Sum;
                bestGenome = currentGenome.Genome;
            }
            else if (currentGenome.LongestSequence == recordSequence)
            {
                if (currentGenome.startIndexOfSequence < indexOfSeq) // If there are several sequences with same length of subsequence of ones, print the one with the leftmost starting index, 
                {
                    indexOfGenome = index;
                    indexOfSeq = currentGenome.startIndexOfSequence;
                    sum = currentGenome.Sum;
                    bestGenome = currentGenome.Genome;
                }
                else if (currentGenome.startIndexOfSequence == indexOfSeq)
                {
                    if (currentGenome.Sum > sum) //, if there are several sequences with same length and starting index, select the sequence with the greater sum of its elements.
                    {
                        indexOfGenome = index;
                        sum = currentGenome.Sum;
                        bestGenome = currentGenome.Genome;
                    }
                }
            }
        }

        Console.WriteLine($"Best DNA sample {indexOfGenome + 1} with sum: {sum}.");
        Console.WriteLine(string.Join(" ", bestGenome));
    }
}