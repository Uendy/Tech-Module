using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        //You are given the coordinates of four points in the 2D plane. 
        //The first and the second pair of points form two different lines. 
        //Print the longer line in format "(X1, Y1)(X2, Y2)" starting with the point that is closer
        //to the center of the coordinate system (0, 0). If the lines are of equal length, print only the first one.

        var listOfPoints = new List<double>();
        for (int i = 0; i < 2; i++)
        {
            ReaderAndGrouper(listOfPoints);
        }

        if (listOfPoints[4] == listOfPoints[9]) // equal in length = print the first
        {
            double x1 = listOfPoints[0];
            double y1 = listOfPoints[1];
            double x2 = listOfPoints[2];
            double y2 = listOfPoints[3];
            PointOrganiser(x1, y1, x2, y2);
        }
        else if (listOfPoints[4] > listOfPoints[9])
        {
            double x1 = listOfPoints[0];
            double y1 = listOfPoints[1];
            double x2 = listOfPoints[2];
            double y2 = listOfPoints[3];
            PointOrganiser(x1, y1, x2, y2);
        }
        else // [9] > [4]
        {
            double x1 = listOfPoints[5];
            double y1 = listOfPoints[6];
            double x2 = listOfPoints[7];
            double y2 = listOfPoints[8];
            PointOrganiser(x1, y1, x2, y2);
        }

    }

    public static List<double> ReaderAndGrouper(List<double> listOfPoints) /// reads points and groups them in the List
    {
        double x1 = double.Parse(Console.ReadLine());
        listOfPoints.Add(x1);
        double y1 = double.Parse(Console.ReadLine());
        listOfPoints.Add(y1);
        double x2 = double.Parse(Console.ReadLine());
        listOfPoints.Add(x2);
        double y2 = double.Parse(Console.ReadLine());
        listOfPoints.Add(y2);

        listOfPoints.Add(LineLength(x1, y1, x2, y2)); // [4] & [9] are the lengths;
        return listOfPoints;
    }

    public static double LineLength(double x1, double y1, double x2, double y2) /// finds the length of the line between the points
    {
        double lineLength = 0.0;

        double xMaxDistance = Math.Abs(x1 - x2);
        double yMaxDistance = Math.Abs(y1 - y2);

        double totalDistanceSquared = Math.Pow(xMaxDistance, 2) + Math.Pow(yMaxDistance, 2);//for pythagoras theorem 

        lineLength = Math.Sqrt(totalDistanceSquared);

        return lineLength;
    }

    public static void PointOrganiser(double x1, double y1, double x2, double y2) /// which of the two points should be printed first
    {
        double firstPointDistance = Math.Abs(x1) + Math.Abs(y1);
        double secondPointDisance = Math.Abs(x2) + Math.Abs(y2);

        if (firstPointDistance <= secondPointDisance)
        {
            Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
        }
        else // secondPoint = closer
        {
            Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
        }
    }
}
