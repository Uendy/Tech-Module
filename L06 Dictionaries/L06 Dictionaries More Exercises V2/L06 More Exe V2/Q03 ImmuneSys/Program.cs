using System;
using System.Collections.Generic;
public class Program
{
    public static void Main()
    {
        //The immune system can calculate the virus’ strength before it fights it. 
        //It is the sum of all the virus name’s letters’ ASCII codes, divided by 3.
        //The immune system can also calculate the time it takes to defeat a virus in seconds.
        //It is equal to the virus strength, multiplied by the length of the virus’ name.
        //When you calculate the time to defeat the virus, convert it to minutes and seconds(500  8m 20s).
        //Do not use any leading zeroes for the minutes and seconds.

        //The virus is fought according to these conditions:
        //•	If the immune system defeats the virus, print: “{ virusName} defeated in { virusDefeatMinutes}m { virusDefeatSeconds}s.”
        //•	If the virus’ strength is more than the immune system’s strength, print “Immune System Defeated.” and exit the program.
        //After a virus is defeated, the immune system regains 20 % of its strength.
        //If the 20 percent exceeds the initial health of the immune system, set it to the initial health instead.

        // Example: The virus “flu1”:
        //•	Virus Strength: 102(f) + 108(l) + 117(u) + 49(1) = 376 / 3 = 125.33 = 125.
        //•	Time to defeat: 125 * 4(virus name length) = 500 seconds -> 8m 20s.
        //Example 2: Encountering “flu1” a second time:
        //•	Time to defeat: (125 * 4) / 3 = 166.66  166 seconds
        //If you encounter a virus any subsequent times, do not decrease its time to defeat further. 

        //When you receive the line “end”, print the status of the immune system in the format “Final Health: { finalHealth}”.

        //ToDo:
        //The immune system can calculate the virus’ strength before it fights it. It is the sum of all the virus name’s letters’ ASCII codes, divided by 3.
        //The immune system can also calculate the time it takes to defeat a virus in seconds.It is equal to the virus strength, multiplied by the length of the virus’ name.


        int maxHealth = int.Parse(Console.ReadLine());
        int currentHealth = maxHealth;

        var diseases = new Dictionary<string, int>();
        //key == disease name, value == 2nd encounter disease time

        while (true)
        {
            string virus = Console.ReadLine();
            if (virus == "end") // check to stop
            {
                break;
            }

            int virusStrength = 0;
            int virusPotency = 0;

            foreach (var symbol in virus.ToCharArray()) // geting virusStrength = the sum of ASCII chars in string
            {
                virusStrength += symbol;
            }
            virusStrength /= 3;


            bool oldDisease = diseases.ContainsKey(virus);
            if(oldDisease)
            {
                virusPotency = diseases[virus];
            }
            else //new disease
            {
                virusPotency = virusStrength * virus.Length;
                diseases[virus] = virusPotency / 3;
            }

            //Printing if immune system won
            Console.WriteLine($"Virus {virus}: {virusStrength} => {virusPotency} seconds");
            if (virusPotency >= currentHealth)
            {
                Console.WriteLine("Immune System Defeated.");
                Environment.Exit(0);
            }

            currentHealth -= virusPotency;

            Console.WriteLine($"{virus} defeated in {virusPotency / 60}m {virusPotency % 60}s.");
            Console.WriteLine($"Remaining health: {currentHealth}");

            //healing
            double regainedHealth = currentHealth * 0.2;
            bool overMaxHealth = currentHealth + regainedHealth >= maxHealth; // not to go over maxHealth
            if (overMaxHealth == true)
            {
                currentHealth = maxHealth;
            }
            else
            {
                currentHealth += (int)regainedHealth;
            }
        }
        Console.WriteLine($"Final Health: {currentHealth}");
    }
}