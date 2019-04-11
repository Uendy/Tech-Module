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
        var blastRadius = arrayOfNums[1];

        while (list.Contains(bombNum))
        {
            int bombIndex = list.IndexOf(bombNum);

            for (int indexRight = bombIndex + 1; indexRight < bombIndex + 1 + blastRadius; indexRight++)
            {
                bool isValidIndex = indexRight < list.Count();
                if (isValidIndex == true)
                {
                    list[indexRight] = int.MinValue;
                }
                else
                {
                    break;
                }
            }

            for (int indexLeft = bombIndex - 1; indexLeft >= bombIndex - blastRadius; indexLeft--)
            {
                bool isValidIndex = indexLeft >= 0;
                if (isValidIndex == true)
                {
                    list[indexLeft] = int.MinValue;
                }
                else
                {
                    break;
                }
            }

            list[bombIndex] = int.MinValue; // since removing them would move all indexs to the right one down
            list.RemoveAll(x => x == int.MinValue);
        }

        Console.WriteLine(list.Sum());
    }
}