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
        var firstPoint = new Circle.Point();

        firstPoint.X = firstCircleInput[0];
        firstPoint.Y = firstCircleInput[1];
        firstCircle.Radius = firstCircleInput[2];

        //2nd Circle input
        var inputPartsOfSecond = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        var secondPoint = new Circle.Point();
        secondPoint.X = inputPartsOfSecond[0];
        secondPoint.Y = inputPartsOfSecond[1];

        var secondCircle = new Circle();
        secondCircle.Radius = inputPartsOfSecond[2];


        // calculate distance between 2 point and see if circ + circ2 is bigger or smaller than distance
        int xDiff = firstPoint.X - Math.Abs(secondPoint.X);
        int yDiff = firstPoint.Y - Math.Abs(secondPoint.Y);
        double cSquared = Math.Pow(xDiff, 2) + Math.Pow(yDiff, 2);
        double distanceBetweenPoints = Math.Sqrt(cSquared);

        bool areIntersected = firstCircle.Radius + secondCircle.Radius >= distanceBetweenPoints;
        Console.WriteLine(areIntersected ? "Yes" : "No");

    }
}