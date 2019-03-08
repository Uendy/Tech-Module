using System;
public class Program
{
    public static void Main()
    {
        //Check any questions here: https://judge.softuni.bg/Contests/Practice/Index/1206#0

        //You will be given a count of wagons in a train n. 
        //On the next n lines you will receive how many people are going to get on each wagon.
        //At the end print the whole train and after that the sum of the people in the train. 

        int numberOfInputs = int.Parse(Console.ReadLine());
        int[] arrayOfWagons = new int[numberOfInputs];

        int sum = 0;

        for (int index = 0; index < numberOfInputs; index++)
        {
            int passengers = int.Parse(Console.ReadLine());
            arrayOfWagons[index] = passengers;
            sum += passengers;
        }

        string ouput = string.Join(" ", arrayOfWagons);
        Console.WriteLine(ouput);
        Console.WriteLine(sum);
    }
}