using System;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        var firstInput = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        var firstRectangle = new Rectangle();
        firstRectangle.Left = firstInput[0];
        firstRectangle.Top = firstInput[1];
        firstRectangle.Width = firstInput[2];
        firstRectangle.Height = firstInput[3];

        var secondInput = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        var secondRectangle = new Rectangle();
        secondRectangle.Left = secondInput[0];
        secondRectangle.Top = secondInput[1];
        secondRectangle.Width = secondInput[2];
        secondRectangle.Height = secondInput[3];

        bool inside = firstRectangle.IsInside(firstRectangle, secondRectangle);
        if (inside == true)
        {
            Console.WriteLine("Inside");
        }
        else
        {
            Console.WriteLine("Not inside");
        }

        Environment.Exit(0);
    }

    static void RectangleReader()
    {

    }
}
