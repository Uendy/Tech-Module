using System;
public class Program
{
    public static void Main()
    {
        // Instructions: Create a program to calculate rectangle’s perimeter, area and diagonal by given its width and height.

        // Example:
        //  Input:          Output:
        //   10               30
        //   5                50
        //                  11.1803398874989

        // Example 2:
        //  Input:          Output:
        //   22.1            64.6
        //   10.2            225.42
        //              24.3402958075698

        // Reading input: (width and height of rectangle)
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());

        // Calculations:
        double perimeter = width * 2 + height * 2;
        double area = width * height;
        double diagonal = Math.Sqrt(Math.Pow(width, 2) + Math.Pow(height, 2));

        // Printing output:
        Console.WriteLine(perimeter);
        Console.WriteLine(area);
        Console.WriteLine(diagonal);
    }
}