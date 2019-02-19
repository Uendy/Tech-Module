using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q11_Geometry_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	Triangle - side and height
            //•	Square - side
            //•	Rectangle - width and height
            //•	Circle - radius

            string desiredShape = Console.ReadLine().ToLower();

            switch (desiredShape)
            {
                case "triangle":
                    double side = double.Parse(Console.ReadLine());
                    double height = double.Parse(Console.ReadLine());
                    Console.WriteLine($"{TriangleAreaCalculator(side,height):f2}");
                    break;

                case "square":
                    double sideOfSquare = double.Parse(Console.ReadLine());
                    Console.WriteLine($"{SquareAreaCalculator(sideOfSquare):f2}");
                    break;

                case "rectangle":
                    double width = double.Parse(Console.ReadLine());
                    double heightOfRectangle = double.Parse(Console.ReadLine());
                    Console.WriteLine($"{RectangleAreaCalculator(width, heightOfRectangle):f2}");
                    break;

                case "circle":
                    double radius = double.Parse(Console.ReadLine());
                    Console.WriteLine($"{CircleAreaCalculator(radius):f2}");
                    break;

                default:
                    Console.WriteLine("Error in string input");
                    break;
            }

        }

        static double TriangleAreaCalculator(double side, double height)
        {
            double area = 0.5 * side * height;
            return area;
        }

        static double SquareAreaCalculator(double sideOfSquare)
        {
            double area = Math.Pow(sideOfSquare, 2);
            return area;
        }

        static double RectangleAreaCalculator(double width, double heightOfRectangle)
        {
            double area = width * heightOfRectangle;
            return area;
        }

        static double CircleAreaCalculator(double radius)
        {
            double area = Math.PI * Math.Pow(radius,2);
            return area;
        }
    }
}
