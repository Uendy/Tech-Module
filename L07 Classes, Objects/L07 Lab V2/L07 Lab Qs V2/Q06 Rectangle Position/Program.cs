using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Write a program to read two rectangles {left, top, width, height} and print whether the first is inside the second.
        //The input is given as two lines, each holding a rectangle, described by 4 integers: left, top, width and height.

        //put in all properties of firstRectangle
        var firstInput = Console.ReadLine();
        var firstRect = RectangleReader(firstInput);

        //secondRectangle aswell
        var secondInput = Console.ReadLine();
        var secondRect = RectangleReader(secondInput);

        //checking if secondRect isInside firstRect
        bool isInside = firstRect.IsInside(firstRect, secondRect);
        if (isInside)
        {
            Console.WriteLine("Inside");
        }
        else
        {
            Console.WriteLine("Not inside");
        }
    }

    public static Rectangle RectangleReader(string input)
    {
        var inputTokens = input.Split(' ').Select(int.Parse).ToArray();

        var currentRectangle = new Rectangle();
        currentRectangle.Left = inputTokens[0];
        currentRectangle.Top = inputTokens[1];
        currentRectangle.Width = inputTokens[2];
        currentRectangle.Height = inputTokens[3];

        return currentRectangle;
    }
}