using System;
using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            //The input lines will be in format: {X} {Y} {Radius}. 

            var inputPartsOfFirst = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var firstPoint = new Point();
            firstPoint.X = inputPartsOfFirst[0];
            firstPoint.Y = inputPartsOfFirst[1];

            var firstCircle = new Circle();
            firstCircle.Radius = inputPartsOfFirst[2];

            //2nd circle input

            var inputPartsOfSecond = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var secondPoint = new Point();
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
            Console.WriteLine(areIntersected? "Yes" : "No");
        }
    }
