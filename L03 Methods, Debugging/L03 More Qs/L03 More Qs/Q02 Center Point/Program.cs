using System;

public class Program
{
    public static void Main()
    {
        //You are given the coordinates of two points on a Cartesian coordinate system:
        //- X1, Y1, X2 and Y2. 
        //Create a method that prints the point that is closest to the center of the coordinate system (0, 0) in the format (X, Y).
        //If the points are on a same distance from the center, print only the first one.

        double x1 = double.Parse(Console.ReadLine());
        double y1 = double.Parse(Console.ReadLine());
        double x2 = double.Parse(Console.ReadLine());
        double y2 = double.Parse(Console.ReadLine());

        ClosestToCenter(x1, y1, x2, y2);
    }

    static void ClosestToCenter(double x1, double y1, double x2, double y2)
    {
        double firstPoint = Math.Abs(x1) + Math.Abs(y1);
        double secondPoint = Math.Abs(x2) + Math.Abs(y2);

        if (firstPoint == secondPoint)
        {
            Console.WriteLine($"({x1}, {y1})");
        }
        else if (firstPoint > secondPoint)
        {
            Console.WriteLine($"({x2}, {y2})"); // since the spray is smaller its closer to the center
        }
        else
        {
            Console.WriteLine($"({x1}, {y1})"); // since then the first coordinate is closer
        }
    }
}
