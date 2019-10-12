using System;
public class Program
{
    public static void Main()
    {
        //Write a program that sets the bit at position p to 0. Print the resulting number.
        // Examples
        //  Input   Output
        //   1313     
        //   5        1281

        //   231      
        //   2        227

        //   111      
        //   6        47

        int number = int.Parse(Console.ReadLine());  
        int position = int.Parse(Console.ReadLine()); 

        number &= ~(1 << position);
        Console.WriteLine(number);
    }
}