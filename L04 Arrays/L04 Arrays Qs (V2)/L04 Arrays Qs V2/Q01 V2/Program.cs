using System;
using System.Linq;
public class LargestCommonEnd
{
    public static void Main()
    {
        string[] firstArray = Console.ReadLine().Split().ToArray();
        string[] secondArray = Console.ReadLine().Split().ToArray();

        int size = Math.Min(firstArray.Length, secondArray.Length);
        int length1 = firstArray.Length;
        int length2 = secondArray.Length;

        int countLeft = 0;
        int countRight = 0;

        // Check left side
        for (int i = 0; i < size; i++)
        {
            if (firstArray[i] == secondArray[i])
            {
                countLeft++;
            }
            else
            {
                break;
            }
        }

        // Check right side
        for (int i = 1; i <= size; i++)
        {
            if (firstArray[length1 - i] == secondArray[length2 - i])
            {
                countRight++;
            }
            else
            {
                break;
            }
        }

        if (countLeft == 0 && countRight == 0)
        {
            Console.WriteLine(countLeft);
        }
        else
        {
            Console.WriteLine(Math.Max(countLeft, countRight));
        }
    } 
}