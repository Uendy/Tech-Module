using System;

public class Program
{
    public static void Main()
    {
        // check any and all questions here: https://judge.softuni.bg/Contests/Practice/Index/1205#0

        //You have a water tank with capacity of 255 liters.
        //On the next n lines, you will receive liters of water, which you have to pour in your tank. 
        //If the capacity is not enough, print “Insufficient capacity!” and continue reading the next line. 
        //On the last line, print the liters in the tank.
        int numberOfInputs = int.Parse(Console.ReadLine());

        int capacity = 255;
        int currentlyOccupied = 0;

        for (int indexOfInput = 0; indexOfInput < numberOfInputs; indexOfInput++)
        {
            int currentBatch = int.Parse(Console.ReadLine());
            if (currentBatch > capacity || currentBatch + currentlyOccupied > capacity)
            {
                Console.WriteLine("Insufficient capacity!");
                continue;
            }
            else
            {
                currentlyOccupied += currentBatch;
            }
        }

        Console.WriteLine(currentlyOccupied);
    }
}
