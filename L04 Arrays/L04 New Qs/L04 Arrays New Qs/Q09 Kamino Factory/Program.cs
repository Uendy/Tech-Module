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

        var listOfDna = new List<int[]>();

        string input = Console.ReadLine();
        while (input != "Clone them!")
        {
            var array = input.Split('!').Select(int.Parse).ToArray();
            listOfDna.Add(array);

            input = Console.ReadLine();
        }

        int longestSeq = 1;
        int indexOfDna = 0;
        int indexOfGenome = 0;

        for (int indexOfList = 0; indexOfList < listOfDna.Count(); indexOfList++) // shift through list of dna strands
        {
            var currentGene = listOfDna[indexOfList];

            int currentSequence = 1;
            int indexOfFirstGenome = 0;

            for (int index = 0; index < currentGene.Length - 1; index++) // first genome
            {
                int firstGenome = currentGene[index];
                if (firstGenome == 0)
                {
                    continue;
                }

                for (int nextIndex = index + 1; nextIndex < currentGene.Length; nextIndex++) // secondGenome
                {
                    int nextGenome = currentGene[nextIndex];

                    bool sequence = firstGenome == nextGenome;
                    if (sequence == true)
                    {
                        currentSequence++;
                        indexOfFirstGenome = firstGenome;
                    }
                    else
                    {
                        if (currentSequence >= longestSeq) //You should select the sequence with the longest subsequence of ones
                        {
                            if (indexOfFirstGenome <= indexOfGenome) //If there are several sequences with same length of subsequence of ones, print the one with the leftmost starting index, 
                            {
                                if (listOfDna[index].Sum() > listOfDna[indexOfDna].Sum()) //if there are several sequences with same length and starting index, select the sequence with the greater sum of its elements.
                                {
                                    longestSeq = currentSequence;
                                    indexOfDna = index;
                                    indexOfGenome = firstGenome;
                                }
                            }
                        }
                        currentSequence = 1;
                        indexOfFirstGenome = nextGenome;
                        break;
                    }

                }
                
            }
        }

        Console.WriteLine($"Best DNA sample {indexOfDna + 1} with sum: {listOfDna[indexOfDna].Sum()}.");
        Console.WriteLine(String.Join(" ", listOfDna[indexOfDna]));

        // what if you solve it with Class and Objects
    }
}