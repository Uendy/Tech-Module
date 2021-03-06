﻿using System;
public class Program
{
    public static void Main()
    {
        //check questions here: https://judge.softuni.bg/Contests/Practice/Index/454#0
        #region
        //Every year a charity marathon takes place in your town in which all major companies are obliged to make donations depending,
        //on the total kilometers ran by runners in a number of days. And this year you have been chosen to create the software for it.

        //The marathon can last for variable number days and a variable number of runners can participate in it on a track that can have a variable length.
        //However, the track that can take only a limited number of runners per day.
        //If the runners that want to take part are more than the capacity,
        //then the number of runners that will run will be equal to the maximum capacity of the track.

        //The amount of money raised per kilometer is voted in advance by all companies and the final money per kilometer is calculated by an average of all votes.

        //The goal is simple, create a program that calculates the total money raised through the marathon.

        //Input
        //•	On the first line of input you will get the length of the marathon in days
        //•	On the second line of input you will get the number of runners that will participate
        //•	On the third line you will get the average number of laps every runner makes
        //•	On the fourth line you will get the length of the track
        //•	On the fifth line you will get the capacity of the track
        //•	On the sixth line you will get the amount of money donated per kilometer
        #endregion

        double days = double.Parse(Console.ReadLine());
        double runners = double.Parse(Console.ReadLine());
        double laps = double.Parse(Console.ReadLine());
        double trackLength = double.Parse(Console.ReadLine());
        double capacity = double.Parse(Console.ReadLine());
        double moneyPerKM = double.Parse(Console.ReadLine());

        var totalRunners = Math.Min(runners, capacity * days);

        var totalMeters = totalRunners * laps * trackLength;

        var totalKiloMeters = totalMeters / 1000;

        var moneyRaised = totalKiloMeters * moneyPerKM;

        Console.WriteLine($"Money raised: {moneyRaised:f2}");
    }
}