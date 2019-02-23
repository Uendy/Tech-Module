using System;
using System.Numerics;
public class Program
{
    public static void Main()
    {
        //You will receive N – an integer, the number of snowballs being made by Tony and Andi.
        //For each snowball you will receive 3 input lines:
        //•	On the first line you will get the snowballSnow – an integer.
        //•	On the second line you will get the snowballTime – an integer.
        //•	On the third line you will get the snowballQuality – an integer.
        //For each snowball you must calculate its snowballValue by the following formula:
        //  (snowballSnow / snowballTime) ^ snowballQuality
        //At the end you must print the highest calculated snowballValue.

        int numberOfSnowballs = int.Parse(Console.ReadLine());
        BigInteger max = 0;

        int maxSnow = 0;
        int maxTime = 0;
        int maxQuality = 0;

        for (int i = 0; i < numberOfSnowballs; i++)
        {
            int snow = int.Parse(Console.ReadLine());
            int time = int.Parse(Console.ReadLine());
            int quality = int.Parse(Console.ReadLine());

            BigInteger value = BigInteger.Pow((snow / time), quality);

            if (value > max)
            {
                max = value;
                maxSnow = snow;
                maxTime = time;
                maxQuality = quality;

            }
        }

        Console.WriteLine($"{maxSnow} : {maxTime} = {max} ({maxQuality})");


    }
}
