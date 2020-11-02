using System;
using System.Collections.Generic;

public class Program
    {
    public static void Main()
    {
        // Instructions: You are given the coordinates of four points in the 2D plane. The first and the second pair of points form two different lines. Print the longer line in format "(X1, Y1)(X2, Y2)" starting with the point that is closer to the center of the coordinate system (0, 0) (You can reuse the method that you wrote for the previous problem). If the lines are of equal length, print only the first one.

        // Example:
        // Input            Output:
        //   2          (4, -3)(-5, -5)
        //   4
        //   -1
        //   2
        //   -5
        //   -5
        //   4
        //   -3

        // Reading input:
        int x1 = int.Parse(Console.ReadLine());
        int y1 = int.Parse(Console.ReadLine());

        int x2 = int.Parse(Console.ReadLine());
        int y2 = int.Parse(Console.ReadLine());

        int x3 = int.Parse(Console.ReadLine());
        int y3 = int.Parse(Console.ReadLine());

        int x4 = int.Parse(Console.ReadLine());
        int y4 = int.Parse(Console.ReadLine());

        double line1Length = FindLength(x1, y1, x2, y2);
        double line2Length = FindLength(x3, y3, x4, y4);
    }

    /// Find length of given line via pythagoras theorem
    public static int FindLength(int x1, int y1, int x2, int y2) 
    {
        int xDiff = x1 + x2;
        int yDiff = y1 + y2;

        double length = Math.Sqrt(Math.Pow(xDiff, 2) + Math.Pow(yDiff, 2));

        return length;
    }
}