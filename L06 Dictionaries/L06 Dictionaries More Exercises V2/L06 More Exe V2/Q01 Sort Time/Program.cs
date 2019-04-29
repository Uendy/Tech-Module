using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    //Check your solutions here: https://judge.softuni.bg/Contests/582.
    public static void Main()
    {
        //Write a program, which receives a list of times (space-separated, 24-hour format) and sorts them in ascending order.
        //Print the sorted times comma-separated.
        //Example: 06:55, 02:30, 23:11 -> 02:30, 06:55, 21:11

        var listOfTimes = Console.ReadLine().Split(' ').ToList();
        listOfTimes = listOfTimes.OrderBy(x => x).ToList();
        string outPut = string.Join(", ", listOfTimes);
        Console.WriteLine(outPut);
    }
}