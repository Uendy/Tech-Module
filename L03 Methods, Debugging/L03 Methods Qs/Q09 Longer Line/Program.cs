
using System;
using System.Collections.Generic;

namespace methodsOrFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstPointX = double.Parse(Console.ReadLine());
            var firstPointY = double.Parse(Console.ReadLine());
            var secondPointX= double.Parse(Console.ReadLine());
            var secondPointY = double.Parse(Console.ReadLine());
            var thirdPointX = double.Parse(Console.ReadLine());
            var thirdPointY = double.Parse(Console.ReadLine());
            var fourthPointX = double.Parse(Console.ReadLine());
            var fourthPointY = double.Parse(Console.ReadLine());

            double firstLineLength = FirstLineLength(firstPointX, firstPointY, secondPointX, secondPointY);
            double secondLineLength = FirstLineLength(thirdPointX, thirdPointY, fourthPointX, fourthPointY);

            if (firstLineLength > secondLineLength)
            {
                Console.WriteLine(ClosestCordinateFinder(firstPointX, firstPointY, secondPointX, secondPointY));
            }
            else if (firstLineLength < secondLineLength)
            {
                Console.WriteLine(ClosestCordinateFinder(thirdPointX, thirdPointY, fourthPointX, fourthPointY));
            }
            else // even
            {
                Console.WriteLine($"({firstPointX}, {firstPointX})({secondPointX}, {secondPointY})");
            }

        }

        static double FirstLineLength(double firstPointX, double firstPointY, double secondPointX, double secondPointY)
        {
            var xLengthDifference = (firstPointX - (secondPointX));
            var yLengthDifference = (firstPointY - (secondPointY));

            var totalLength = Math.Sqrt(Math.Pow(xLengthDifference, 2) + Math.Pow(yLengthDifference,2));

            return totalLength;
        }

        static string ClosestCordinateFinder(double x1, double y1, double x2, double y2)
        {
            string cordinates = null;

            double firstPointLine = Math.Sqrt(x1 * x1 + y1 * y1);
            double secondPointLine = Math.Sqrt(x2 * x2 + y2 * y2);
            
            if (firstPointLine <= secondPointLine)
            {
                cordinates = $"({x1}, {y1})({x2}, {y2})";
                  return cordinates;
            }
            else
            {
                cordinates = $"({x2}, {y2})({x1}, {y1})";
                   return cordinates;
            }

        }

    }
}