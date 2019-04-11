using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Write a program that reads a sequence of numbers and a special bomb number with a certain power. 
        //Your task is to detonate every occurrence of the special bomb number and according to its power 
        //his neighbors from left and right. 
        //Detonations are performed from left to right and all detonated numbers disappear.
        //Finally print the sum of the remaining elements in the sequence.

        var list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

        var arrayOfNums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        var bombNum = arrayOfNums[0];
        int indexOfBomb = list.IndexOf(bombNum);
        var blastRadius = arrayOfNums[1];

        while (list.Contains(bombNum))
        {
            //defuse left of bomb
            bool blowsUpSafely = indexOfBomb <= list.Count() - 1 - blastRadius; // maybe not -1 
            if (blowsUpSafely == true)
            {
                list.RemoveRange(indexOfBomb + 1, blastRadius);
            }
            else
            {
                int indexsLeft = list.Count() - 1 - (indexOfBomb);
                if (indexsLeft > 0)
                {
                    list.RemoveRange(indexOfBomb + 1, indexsLeft);
                }
            }
            list.Reverse();

            //defuse right of bomb (after Reverse also left)
            int newIndexOfBomb = list.IndexOf(bombNum);
            bool blowsUpSafelyAgain = newIndexOfBomb <= list.Count() - 1 - blastRadius; // maybe not -1 
            if (blowsUpSafelyAgain == true)
            {
                list.RemoveRange(newIndexOfBomb + 1, blastRadius);
            }
            else
            {
                int indexsLeft = list.Count() - 1 - (newIndexOfBomb);
                if (indexsLeft > 0)
                {
                    list.RemoveRange(newIndexOfBomb, indexsLeft + 1);
                }
            }
            list.Reverse();

            list.Remove(bombNum);
        }
        Console.WriteLine(list.Sum());
    }
}