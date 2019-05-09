using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Create class Circle with properties Center and Radius.
        //The center is a point with coordinates X and Y (make a class Point).
        //Write a method bool Intersect(Circle c1, Circle c2) that tells whether the two given circles intersect or not.

        //Write a program that tells if two circles intersect.
        //The input lines will be in format: { X}{ Y}{ Radius}.
        //Print as output “Yes” or “No”.

        //first Circle Input
        var firstCircleInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        var firstCircle = new Circle();
        var firstPoint = new Point() { X = firstCircleInput[0], Y = firstCircleInput[1]};
        firstCircle.Radius = firstCircleInput[2];

        //2nd Circle input
        var secondCircleInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        var secondPoint = new Point() { X = };
        secondPoint.X = secondCircleInput[0];
        secondPoint.Y = secondCircleInput[1];

        var secondCircle = new Circle();
        secondCircle.Radius = secondCircleInput[2];


        // calculate distance between 2 point and see if circ + circ2 is bigger or smaller than distance
        double distanceBetweenPoints = DifferenceCalculator(firstPoint, secondPoint);

        //final check
        bool areIntersected = firstCircle.Radius + secondCircle.Radius >= distanceBetweenPoints;
        Console.WriteLine(areIntersected ? "Yes" : "No");
    }

    public static double DifferenceCalculator(Point firstPoint, Point secondPoint)
    {
        double distanceBetweenPoints = 0.0;
        int xDiff = firstPoint.X - Math.Abs(secondPoint.X);
        int yDiff = firstPoint.Y - Math.Abs(secondPoint.Y);
        double cSquared = Math.Pow(xDiff, 2) + Math.Pow(yDiff, 2);
        distanceBetweenPoints = Math.Sqrt(cSquared);
        return distanceBetweenPoints;
    }
}