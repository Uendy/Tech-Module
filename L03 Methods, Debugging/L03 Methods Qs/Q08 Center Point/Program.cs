using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q08_Center_Point
{
    class Program
    {
        
           //Where I went wrong
           //I missunderstood the question, though it wanter the closest indevidual points, but it was the closest pair of points,
           // and not to print only 1 indevidual point if the 2 were the same, but the closest pair if both pairs were of equal
           //distance from one another


            //static void Main(string[] args)
            //{
            //    double firstX = double.Parse(Console.ReadLine());
            //    double firstY = double.Parse(Console.ReadLine());
            //    double secondX = double.Parse(Console.ReadLine());
            //    double secondY = double.Parse(Console.ReadLine());
            //    CenterPoint(firstX, firstY, secondX, secondY);



            //}
            //static void CenterPoint(double x1, double y1, double x2, double y2)
            //{
            //    if (Math.Sqrt(Math.Pow(x1, 2) + Math.Pow(y1, 2)) < Math.Sqrt(Math.Pow(x2, 2) + Math.Pow(y2, 2)))
            //        Console.WriteLine($"({x1}, {y1})");
            //    else
            //        Console.WriteLine($"({x2}, {y2})");

            //}
        
    
        //my solution 80/100, still not too bad for not understanding what is asked.
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            Console.WriteLine(ClosestCordinateFinder(x1,y1,x2,y2));
        }

        static string ClosestCordinateFinder(double x1, double y1, double x2, double y2)
        {
            string cordinates = null;

            double closestOnXAxis;

            if (Math.Abs(x1) <= Math.Abs(x2))
            {
                closestOnXAxis = x1;
            }
            else
            {
                closestOnXAxis = x2;
            }

            double closestOnYAxis;

            if (Math.Abs(y1) <= Math.Abs(y2))
            {
                closestOnYAxis = y1;
            }
            else
            {
                closestOnYAxis = y2;
            }

            if (closestOnXAxis == closestOnYAxis)
            {
                cordinates = $"({closestOnXAxis}, )";
                return cordinates;
            }
            else
            {
                cordinates = $"({closestOnXAxis}, {closestOnYAxis})";
                return cordinates;
            }
        }
    }
}
