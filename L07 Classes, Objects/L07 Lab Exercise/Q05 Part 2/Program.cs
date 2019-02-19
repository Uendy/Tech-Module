using System;
using System.Collections.Generic;
using System.Linq;

 class Program
 {
     static void Main(string[] args)
     {
         int numberOfInputs = int.Parse(Console.ReadLine());
         var listOfPoints = new List<Point>();

         for (int indexOfInput = 0; indexOfInput < numberOfInputs; indexOfInput++)
         {
             var inputParts = Console.ReadLine()
                 .Split(' ')
                 .Select(int.Parse)
                 .ToArray();

             var point = new Point {
                 X = inputParts[0],
                 Y = inputParts[1]
             };

             listOfPoints.Add(point);
         }

         double lowestDiff = double.MaxValue;
         var listOfImportantPoints = new List<Point>();

         // very smart way of cycling through a list while comparing 2 elements of it
         for (int indexOfFirst = 0; indexOfFirst < numberOfInputs - 1; indexOfFirst++)
         {
             for (int indexOfSecond = indexOfFirst + 1; indexOfSecond < numberOfInputs; indexOfSecond++)
             {
                 var firstPoint = listOfPoints[indexOfFirst];
                 var secondPoint = listOfPoints[indexOfSecond];
                 lowestDiff = CalcDifference(firstPoint, secondPoint, lowestDiff, listOfImportantPoints);
             }
         }
         lowestDiff = Math.Round(lowestDiff, 3);
         Console.WriteLine($"{lowestDiff:f3}");
         foreach (var point in listOfImportantPoints)
         {
             Console.WriteLine($"({point.X}, {point.Y})");
         }
     }

     static double CalcDifference(Point firstPoint,  Point secondPoint, double lowestDiff, List<Point> listOfImportantPoints)
     {
         int xDiff = firstPoint.X - secondPoint.X;
         int yDiff = firstPoint.Y - secondPoint.Y;
         double bothDiffsSquared = Math.Pow(xDiff, 2) + Math.Pow(yDiff, 2);
         double actualDiff = Math.Sqrt(bothDiffsSquared);

         bool newLowestDiff = actualDiff < lowestDiff;
         if (newLowestDiff == true)
         {
             listOfImportantPoints.Clear();
             listOfImportantPoints.Add(firstPoint);
             listOfImportantPoints.Add(secondPoint);
             return actualDiff;
         }
         else
         {
             return lowestDiff;
         }
     }
 }
