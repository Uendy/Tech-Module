using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q05_Closest_Two_Points
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());
            Point[] points = new Point[numberOfInputs];

            for (int i = 0; i < numberOfInputs; i++)
            {
                var point = new Point();

                int[] pointCoordinates = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                point.X = pointCoordinates[0];
                point.Y = pointCoordinates[1];

                points[i] = point;
            }

            double lowestDistance = 0.0;
            var listOfFinalPoints = new List<Point>();

            for (int indexOfFirst = 0; indexOfFirst < numberOfInputs; indexOfFirst++)
            {
                var currentFirstPoint = points[indexOfFirst];

                for (int indexOfSecond = 1; indexOfSecond < numberOfInputs; indexOfSecond++)
                {
                    bool sameIndex = indexOfFirst == indexOfSecond;
                    if (sameIndex == true)
                    {
                        continue;
                    }

                    var currentSecondPoint = points[indexOfSecond];

                   lowestDistance =  DistanceCalc(currentFirstPoint, currentSecondPoint, listOfFinalPoints, lowestDistance, indexOfFirst, indexOfSecond);
                }
            }

            lowestDistance = Math.Round(lowestDistance, 3);
            Console.WriteLine($"{lowestDistance:f3}");
            foreach (var item in listOfFinalPoints)
            {
                Console.WriteLine($"({item.X}, {item.Y})");
            }

           // Environment.Exit(0);
        }
        static double DistanceCalc(Point currentFirstPoint, Point currentSecondPoint, List<Point> listOfFinalPoints, double lowestDistance, int indexOfFirst, int indexOfSecond)
        {

            int xDiff = currentFirstPoint.X - currentSecondPoint.X;
            int yDiff = currentFirstPoint.Y - currentSecondPoint.Y;
            double sumOfDiffs = Math.Pow(xDiff, 2) + Math.Pow(yDiff, 2);
            double result = Math.Sqrt(sumOfDiffs);
            bool firstResult = indexOfFirst == 0 && indexOfSecond == 1;
            if (firstResult == true)
            {
                listOfFinalPoints.Add(currentFirstPoint);
                listOfFinalPoints.Add(currentSecondPoint);
                return lowestDistance = result;
                listOfFinalPoints.Add(currentSecondPoint);
            }
            else
            {

                bool newLowestDistance = result < lowestDistance;
                if (newLowestDistance == true)
                {
                    listOfFinalPoints.Clear();

                    listOfFinalPoints.Add(currentFirstPoint);
                    listOfFinalPoints.Add(currentSecondPoint);
                    return lowestDistance = result;
                }
                else
                {
                    return lowestDistance;
                }
            }

        }
    }
}
