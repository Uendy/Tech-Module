using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Write a program to read n points and find the closest two of them.

        int numberOfPoints = int.Parse(Console.ReadLine());

        var listOfPoints = new List<Point>();

        // reading all inputs and inserting them into each points properties (x, y), then adding them to list of points
        for (int index = 0; index < numberOfPoints; index++)
        {
            var currentInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var currentPoint = new Point();
            currentPoint.X = currentInput[0];
            currentPoint.Y = currentInput[1];
            listOfPoints.Add(currentPoint);
        }

        // initializing info
        double smallestDiff = double.MaxValue;
        int indexOfFirstPoint = 0;
        int indexOfSecondPoint = 0;

        // comparing the points to eachother in list
        for (int firstIndex = 0; firstIndex < listOfPoints.Count(); firstIndex++)
        {
            var firstPoint = listOfPoints[firstIndex];

            for (int secondIndex = firstIndex + 1; secondIndex < listOfPoints.Count(); secondIndex++)
            {
                var secondPoint = listOfPoints[secondIndex];

                //diff calculations
                int xDifference = Math.Abs(firstPoint.X - secondPoint.X);
                int yDifference = Math.Abs(firstPoint.Y - secondPoint.Y);
                double currentDiff = Math.Sqrt(Math.Pow(xDifference, 2) + Math.Pow(yDifference, 2));

                //check if new record small diff
                bool newSmallest = currentDiff < smallestDiff;
                if (newSmallest)
                {
                    smallestDiff = currentDiff;
                    indexOfFirstPoint = firstIndex;
                    indexOfSecondPoint = secondIndex;
                }
            }

        }

        // Printing
        Console.WriteLine($"{smallestDiff:f3}");
        Console.WriteLine(listOfPoints[indexOfFirstPoint]);
        Console.WriteLine(listOfPoints[indexOfSecondPoint]);
    }
}