using System;
public class Program
{
    public static void Main()
    {
        // Instructions: Write a program that can calculate the area of four different geometry figures - triangle, square, rectangle and circle.
        // On the first line you will get the figure type. Next you will get parameters for the chosen figure, each on a different line:
        // •	Triangle - side and height
        // •	Square - side
        // •	Rectangle - width and height
        // •	Circle - radius
        // The output should be rounded to the second digit after the decimal point:

        // Example: 
        // Input	   Output
        // triangle     9.00
        //   3
        //   6   

        // Reading input:
        string shape = Console.ReadLine().ToLower();

        switch (shape) // check which shape, the rest is pretty explanatory: read following inputs, method to calc subsequent area, round and print
        {
            case "triangle":
                int triSide = int.Parse(Console.ReadLine());
                int triHeight = int.Parse(Console.ReadLine());
                double triArea = CalcTriangleArea(triSide, triHeight);
                Console.WriteLine($"{Math.Round(triArea, 2):f2}");
                break;

            case "square":
                int SqSide = int.Parse(Console.ReadLine());
                double sqArea = CalcSquareArea(SqSide);
                Console.WriteLine($"{Math.Round(sqArea, 2):f2}");
                break;

            case "rectangle":
                int reWidth = int.Parse(Console.ReadLine());
                int reHeight = int.Parse(Console.ReadLine());
                double reArea = CalcRectangleArea(reWidth, reHeight);
                Console.WriteLine($"{Math.Round(reArea, 2):f2}");
                break;

            case "circle":
                int ciRadius = int.Parse(Console.ReadLine());
                double ciArea = CalcCircleArea(ciRadius);
                Console.WriteLine($"{Math.Round(ciArea, 2):f2}");
                break;
        }
    }
    public static double CalcTriangleArea(int triSide, int triHeight)
        {
            double area = (triSide * triHeight) / 2;
            return area;
        }
    public static double CalcSquareArea(int sqSide)
    {
        double area = sqSide * sqSide;
        return area;
    }
    public static double CalcRectangleArea(int reWidth, int reHeight)
    {
        double area = reHeight * reHeight;
        return area;
    }
    public static double CalcCircleArea(int ciRadius)
    {
        double area = Math.PI * Math.Pow(ciRadius, 2);
        return area;
    }
}