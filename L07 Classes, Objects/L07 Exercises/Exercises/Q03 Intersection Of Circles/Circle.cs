using System;

public class Circle
{
    public int Radius { get; set; }

    public double Cicumfrance => Math.Pow(Math.PI, 2) * Radius;

}
