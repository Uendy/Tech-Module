using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q04_Distance_Between_Two_Points
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstPoint = new Point { };
            var secondPoint = new Point { };

            for (int i = 0; i < 2; i++)
            {
                int[] input = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                if (i == 0)
                {
                    firstPoint.X = input[0];
                    firstPoint.Y = input[1];
                }
                else
                {
                    secondPoint.X = input[0];
                    secondPoint.Y = input[1];
                }
            }

            int xDiff = firstPoint.X - secondPoint.X;
            int yDiff = firstPoint.Y - secondPoint.Y;

            double euclidianDistance = Math.Sqrt(Math.Pow(xDiff, 2) + Math.Pow(yDiff, 2));

            Console.WriteLine($"{euclidianDistance:f3}");
        }
    }
}

