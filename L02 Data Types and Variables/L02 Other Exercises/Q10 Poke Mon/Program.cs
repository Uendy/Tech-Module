using System;
public class Program
{
    public static void Main()
    {
        //The Poke Mon pokes his target, and then proceeds to poke another target. 
        //The distance between his targets reduces his poke power.
        //You will be given the poke power the Poke Mon has, N – an integer.
        //Then you will be given the distance between the poke targets, M – an integer.
        //Then you will be given the exhaustionFactor Y – an integer.

        //Your task is to start subtracting M from N until N becomes less than M, 
        //i.e.the Poke Mon does not have enough power to reach the next target.
        //Every time you subtract M from N that means you’ve reached a target and poked it successfully. 
        //COUNT how many targets you’ve poked – you’ll need that count.
        //The Poke Mon becomes gradually more exhausted.IF N becomes equal to EXACTLY 50 % of its original value,
        //you must divide N by Y, if it is POSSIBLE.This DIVISION is between integers.
        //If a division is not possible, you should NOT do it.Instead, you should continue subtracting.
        //After dividing, you should continue subtracting from N, until it becomes less than M.
        //When N becomes less than M, you must take what has remained of N and the count of targets you’ve poked, 
        //and print them as output.

        int pokePower = int.Parse(Console.ReadLine()); //N
        int distanceToTarget = int.Parse(Console.ReadLine()); // M
        int exhaustionFactor = int.Parse(Console.ReadLine()); //Y
        int numberOfTargetsHit = 0;

        double halfPower = pokePower * 0.5;

        while (pokePower >= distanceToTarget)
        {
            pokePower -= distanceToTarget;
            numberOfTargetsHit++;

            if (pokePower == halfPower && exhaustionFactor > 0)
            {
                pokePower /= exhaustionFactor;
            }
        }

        Console.WriteLine(pokePower);
        Console.WriteLine(numberOfTargetsHit);

    }
}
