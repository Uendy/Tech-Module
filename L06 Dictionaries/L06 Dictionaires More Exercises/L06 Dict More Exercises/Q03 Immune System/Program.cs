using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q03_Immune_System
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialHealth = int.Parse(Console.ReadLine());
            var listOfDiseases = new Dictionary<string, int>(); // name, time
            var listOfDiseaseStrength = new Dictionary<string, int>();
            var diseaseEncounters = new Dictionary<string, int>(); // name, times encountered
            int remainingHealth = initialHealth;

            string input = Console.ReadLine();
            while (input != "end")
            {
                bool alreadyHaveKey = listOfDiseases.ContainsKey(input);
                if (alreadyHaveKey == false)
                {
                    listOfDiseases[input] = 0;
                    listOfDiseaseStrength[input] = 0;
                    diseaseEncounters[input] = 1;

                    int diseaseStrength = 0;
                    var diseaseDeconstructed = input.ToArray();

                    foreach (char item in diseaseDeconstructed)
                    {
                        diseaseStrength += item;
                    }
                    diseaseStrength /= 3;
                    listOfDiseaseStrength[input] = diseaseStrength;

                    int timeToDefeatDisease = diseaseStrength * input.Length; // seconds
                    listOfDiseases[input] = timeToDefeatDisease;

                }
                else // already fought it
                {
                    if (diseaseEncounters[input] == 1) // so we do not divide it more than once
                    {
                        listOfDiseases[input] /= 3;
                        diseaseEncounters[input] = 2;
                    }
                }

                int timeNeededForDisease = listOfDiseases[input];

                if (alreadyHaveKey == false)
                {
                    Console.WriteLine($"Virus {input}: {listOfDiseases[input] / input.Length} => {timeNeededForDisease} seconds");
                }
                else // already fought it (problem is here!)
                {
                    Console.WriteLine($"Virus {input}: {listOfDiseaseStrength[input]} => {timeNeededForDisease} seconds");
                }

                // make the seconds and minutes
                int minutes = timeNeededForDisease / 60;
                int seconds = timeNeededForDisease % 60;

                // the life calculations
                remainingHealth -= timeNeededForDisease;

                bool dead = remainingHealth <= 0;
                if (dead == true)
                {
                    Console.WriteLine($"Immune System Defeated.");
                    Environment.Exit(0);
                }
                else // still alive
                {
                    Console.WriteLine($"{input} defeated in {minutes}m {seconds}s.");
                    Console.WriteLine($"Remaining health: {remainingHealth}");
                }

                //After a virus is defeated, the immune system regains 20% of its strength. If the 20 percent exceeds the initial health of the immune system, set it to the initial health instead.
                double healthRegenarated = Math.Floor(remainingHealth * 0.2);
                bool aboveMaxHealth = remainingHealth + healthRegenarated >= initialHealth;
                if (aboveMaxHealth == true)
                {
                    remainingHealth = initialHealth;
                }
                else
                {
                    remainingHealth += (int)healthRegenarated;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Final Health: {remainingHealth}");
            
        }
    }
}
