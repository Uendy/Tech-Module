using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //You need to categorize dragons by their type. 
        //For each dragon, identified by name, keep information about his stats.
        //Type is preserved as in the order of input, but dragons are sorted alphabetically by name.
        //For each type, you should also print the average damage, health and armor of the dragons. 
        //For each dragon, print his own stats. 

        //There may be missing stats in the input, though.
        //If a stat is missing you should assign it default values.
        //Default values are as follows: health 250, damage 45, and armor 10.
        //Missing stat will be marked by null.

        //The input is in the following format { type}{ name}{ damage}{ health}{ armor}.
        //Any of the integers may be assigned null value.
        //See the examples below for better understanding of your task.

        //If the same dragon is added a second time, the new stats should overwrite the previous ones.
        //Two dragons are considered equal if they match by both name and type.

        var dragonsCollection = new Dictionary<string, SortedDictionary<string, Dragon>>();
        //outerDict: key = DragonType, value = innerDict
        //innerDict: key = DragonName, value = the actual dragon (object)

        int numberOfInputs = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfInputs; i++)
        {
            var dragonInfoTokens = Console.ReadLine().Split(' ').ToArray();

            string type = dragonInfoTokens[0];
            string name = dragonInfoTokens[1];

            bool damageParsed = int.TryParse(dragonInfoTokens[2], out int damage);
            if (damageParsed == false)
            {
                damage = 45;
            }

            bool healthParsed = int.TryParse(dragonInfoTokens[3], out int health);
            if (healthParsed == false)
            {
                health = 250;
            }

            bool armorParsed = int.TryParse(dragonInfoTokens[4], out int armor);
            if (armorParsed == false)
            {
                armor = 10;
            }

            // adding type if it dosen't already exist
            bool newType = !dragonsCollection.ContainsKey(type);
            if (newType)
            {
                dragonsCollection[type] = new SortedDictionary<string, Dragon>();
            }

            // make the dragon object
            var currentDragon = new Dragon()
            {
                Type = type,
                Name = name,
                Health = health,
                Damage = damage,
                Armor = armor
            };

            dragonsCollection[type][name] = currentDragon;
        }


        foreach (var type in dragonsCollection.Keys) //Printing and determening aggregate stats
        {
            double averageDamage = 0.0;
            var listOfDamage = new List<int>();
            foreach (var name in dragonsCollection[type].Keys)
            {
                var currentDragon = dragonsCollection[type][name];
                int currentDamage = currentDragon.Damage;
                listOfDamage.Add(currentDamage);
            }
            averageDamage = listOfDamage.Average();


            double averageHealth = 0.0;
            var listOfHealth = new List<int>();
            foreach (var name in dragonsCollection[type].Keys)
            {
                var currentDragon = dragonsCollection[type][name];
                var currentHealth = currentDragon.Health;
                listOfHealth.Add(currentHealth);
            }
            averageHealth = listOfHealth.Average();

            double averageArmor = 0.0;
            var listOfArmor = new List<int>();
            foreach (var name in dragonsCollection[type].Keys)
            {
                var currentDragon = dragonsCollection[type][name];
                var currentArmor = currentDragon.Armor;
                listOfArmor.Add(currentArmor);
            }
            averageArmor = listOfArmor.Average();


            //printing
            Console.WriteLine($"{type}::({averageDamage:f2}/{averageHealth:f2}/{averageArmor:f2})");

            foreach (var dragon in dragonsCollection[type].Keys)
            {
                
                Console.WriteLine($"-{dragon} -> " +
                    $"damage: {dragonsCollection[type][dragon].Damage}," +
                    $" health: {dragonsCollection[type][dragon].Health}," +
                    $" armor: {dragonsCollection[type][dragon].Armor}");
            }
        }
    }
}