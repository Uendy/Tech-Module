using System;
public class Program
{
    public static void Main()
    {
        // Instructions: Write a program that can calculate the length of the face diagonals, space diagonals, volume and surface area of a cube (http://www.mathopenref.com/cube.html) by a given side. On the first line you will get the side of the cube. On the second line is given the parameter (face, space, volume or area).
        // Output should be rounded to the second digit after the decimal point:

        // Example:
        // Input	Output
        //  5        7.07
        // face

        // Example 2:
        // Input     Output
        //   5       125.00
        // Volume

        // Reading input:
        int side = int.Parse(Console.ReadLine());
        string function = Console.ReadLine();

        // Reroute to method via functions
        switch (function)
        {
            case "face":
                double face = FindFace(side);
                Console.WriteLine(face);
                    break;

            case "space":
                double space = FindSpace(side);
                Console.WriteLine(space);
                    break;

            case "volume":
                double volume = FindVolume(side);
                Console.WriteLine(volume);
                break;

            case "area":
                double area = FindArea(side);
                Console.WriteLine(area);
                break;
        }
    }
     public static double FindFace(int side)
     {
        double face = Math.Sqrt(2 * Math.Pow(side, 2));
        return Math.Round(face, 2);
     }
    public static double FindSpace(int side)
    {
        double space = Math.Sqrt(3 * Math.Pow(side, 2));
        return Math.Round(space, 2);
    }
    public static double FindVolume(int side)
    {
        double volume = Math.Pow(side, 3);
        return Math.Round(volume, 2);
    }

    public static double FindArea(int side)
    {
        double area = 6 * Math.Pow(side, 2);
        return Math.Round(area, 2);
    }
}