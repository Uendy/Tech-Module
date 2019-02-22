using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Write a program, which calculates the volume of n beer kegs. 
        //You will receive in total 3 * n lines. Each three lines will hold information for a single keg. 
        //First up is the model of the keg, after that is the radius of the keg, and lastly is the height of the keg.
        //Calculate the volume using the following formula: π* r^ 2 * h.
        //At the end, print the model of the biggest keg.

        int numberOfKegs = int.Parse(Console.ReadLine());

        var dictOfKegs = new Dictionary<string, double>();

        for (int indexOfKeg = 0; indexOfKeg < numberOfKegs; indexOfKeg++)
        {
            string model = Console.ReadLine();

            decimal radius = decimal.Parse(Console.ReadLine());

            int height = int.Parse(Console.ReadLine());

            double volume = Math.PI * Math.Pow((double)radius, 2) * height;

            dictOfKegs[model] = volume;
        }

        var resultDict = dictOfKegs.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value).Keys.First();
        Console.WriteLine(resultDict);

    }
}

