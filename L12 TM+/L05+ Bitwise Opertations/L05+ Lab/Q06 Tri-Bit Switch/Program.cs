using System;
public class Program
{
    public static void Main()
    {
        //Write a program that inverts the 3 bits from position p to the left with their opposites (e.g. 111 -> 000, 101 -> 010) in 32-bit number.
        //Print the resulting number on the console.

        //Examples

        //Input       Output                     Details
        //1234         1874           00000000000000000000010011010010
        // 7                          00000000000000000000011101010010

        //44444        44524          00000000000000001010110110011100
        //4                           00000000000000001010110111101100

        int num = int.Parse(Console.ReadLine());
        int startingPosition = int.Parse(Console.ReadLine());

        long mask = 7 << startingPosition;
        long result = num ^ mask;

        Console.WriteLine(result);
    }
}