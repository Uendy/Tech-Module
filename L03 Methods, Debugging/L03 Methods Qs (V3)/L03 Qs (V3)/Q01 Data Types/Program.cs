using System;
public class Program
{
    public static void Main()
    {
        // Instructions:
        //	Write a program that, depending on the first line of the input, reads an int, double or string.

        //•	If the data type is int, multiply the number by 2.
        //•	If the data type is real, multiply the number by 1.5 and format it to the second decimal point.
        //•	If the data type is string, surround the input with "$".

        //Print the result on the console.

        // Reading input:
        string input = Console.ReadLine();

        // Try parsing without bug:
        try // see if you can parse to int
        {
            var tryInt = int.Parse(input);
            var succeedInt = tryInt * 2;
            Console.WriteLine(succeedInt);
        }
        catch (Exception)
        {
            try // see if you can parse to double
            {
                var tryDouble = double.Parse(input);
                var succeedDouble = tryDouble * 1.5;
                Console.WriteLine(succeedDouble);
            }
            catch (Exception) // Its a string
            {
                Console.WriteLine($"${input}$");
            }
        }
    }
}