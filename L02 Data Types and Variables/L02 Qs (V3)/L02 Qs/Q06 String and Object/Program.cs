using System;
public class Program
{
    public static void Main()
    {
        // Instructions: Declare two string variables and assign them with “Hello” and “World”. Declare an object variable and assign it with the concatenation of the first two variables (mind adding an interval between). Declare a third string variable and initialize it with the value of the object variable (you should perform type casting).

        // Example: 
        // Input      Output
        // Hello    Hello World
        // World

        // Reading input:
        string firstString = Console.ReadLine();
        string secondString = Console.ReadLine();

        // Concatinate both string:
        string concat = string.Concat(firstString, " ", secondString);

        // Printing ouput:
        Console.WriteLine(concat);
    }
}