using System;
public class Program
{
    public static void Main()
    {
        // Instructions: You are given the coordinates of two points on a Cartesian coordinate system - X1, Y1, X2 and Y2. Create a method that prints the point that is closest to the center of the coordinate system (0, 0) in the format (X, Y). If the points are on a same distance from the center, print only the first one.
        // Example:
        // Input	Output
        // 2        (-1, 2)
        // 4
        // - 1
        // 2

        // Reading input:
        int x1 = int.Parse(Console.ReadLine());
        int y1 = int.Parse(Console.ReadLine());

        int x2 = int.Parse(Console.ReadLine());
        int y2 = int.Parse(Console.ReadLine());

        // Method and ouput
        ClosestPoints(x1, y1, x2, y2);

    }

    /// Method that finds distance to center and prints result
    public static void ClosestPoints(int x1, int y1, int x2, int y2)
    {
        // Find distances from center, smaller distance = closer
        int pointOneDistnace = Math.Abs(x1) + Math.Abs(y1);
        int pointTwoDistance = Math.Abs(x2) + Math.Abs(y2);

        if (pointOneDistnace <= pointTwoDistance) // if p1 is smaller or equal to p2 we print it
        {
            Console.WriteLine($"({x1}, {y1})");
        }
        else
        {
            Console.WriteLine($"({x2}, {y2})");
        }
    }
}