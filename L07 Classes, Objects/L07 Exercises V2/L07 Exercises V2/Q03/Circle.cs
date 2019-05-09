using System;
public class Circle
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public int Radius { get; set; }

    public double Cicumfrance => Math.Pow(Math.PI, 2) * Radius;
}