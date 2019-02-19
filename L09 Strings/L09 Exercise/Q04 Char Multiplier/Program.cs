using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine().Split(' ').ToArray().OrderByDescending(x => x.Length).ToArray();
        var firstString = input[0];
        var secondString = input[1];

        Console.WriteLine(CharMultiplier(firstString, secondString));

    }

    static int CharMultiplier(string firstString, string secondString)
    {
        int sum = 0;

        var firstStringAsCharArray = firstString.ToCharArray();
        var secondStringAsCharArray = secondString.ToCharArray();

        for (int index = 0; index < firstString.Length; index++)
        {
            bool passedSecondString = index >= secondString.Count();
            if (!passedSecondString)
            {
                sum += firstStringAsCharArray[index] * secondStringAsCharArray[index];
            }
            else
            {
                sum += firstStringAsCharArray[index];
            }
        }


        return sum;
    }
}
