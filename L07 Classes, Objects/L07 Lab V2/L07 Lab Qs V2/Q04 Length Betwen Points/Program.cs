using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Write a method to calculate the distance between two points p1 { x1, y1} and p2 { x2, y2}. 
        //Write a program to read two points(given as two integers) and print the Euclidean distance between them.

        var firstPoint = new Point();
        var firstInput = Console.ReadLine().Split(' ').ToArray();
        firstPoint.X = int.Parse(firstInput[0]);
        firstPoint.Y = int.Parse(firstInput[1]);

        var secondPoint = new Point();
        var secondInput = Console.ReadLine().Split(' ').ToArray();
        secondPoint.X = int.Parse(secondInput[0]);
        secondPoint.Y = int.Parse(secondInput[1]);

        var xDifference = Math.Abs(firstPoint.X - secondPoint.X);
        var yDifference = Math.Abs(firstPoint.Y - secondPoint.Y);

        //a^2 + b^2 = c^2 Pythagoras
        double distance = Math.Sqrt(Math.Pow(xDifference, 2) + Math.Pow(yDifference, 2));

        Console.WriteLine($"{distance:f3}");
    }
}