﻿using System;
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

        var dragonsCollection = new Dictionary<string, SortedDictionary<string, object>>();
        //outerDict: key = DragonType, value = innerDict
        //innerDict: key = DragonName, value = the actual dragon (object)

        int numberOfInputs = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfInputs; i++)
        {
            var dragonInfoTokens = Console.ReadLine().Split(' ').ToArray();

            string type = dragonInfoTokens[0];
            string name = dragonInfoTokens[1];

            int health = 0;
            bool healthParsed = int.TryParse(dragonInfoTokens[2], out health);
            if (health == 0)
            {
                health = 250;
            }

            int damage = 0;
            bool damageParsed = int.TryParse(dragonInfoTokens[3], out damage);
            if (damage == 0)
            {
                damage = 45;
            }

            int armor = 0;
            bool armorParsed = int.TryParse(dragonInfoTokens[4], out armor);
            if (armor == 0)
            {
                armor = 10;
            }

            // adding type if it dosen't already exist
            bool newType = !dragonsCollection.ContainsKey(type);
            if (newType)
            {
                dragonsCollection[type] = new SortedDictionary<string, object>();
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

        //ToDo: average for each type
        //Printing


        foreach (var type in dragonsCollection.Keys)
        {
            double averageDamage = 0.0;
            double averageHealth = 0.0;
            double averageArmor = 0.0;

            var listOfDamage = new List<int>();
            foreach (var name in dragonsCollection[type].Keys)
            {
                var currentDragon = dragonsCollection[type][name];
                //listOfDamage.Add(currentDragon.Health);
                //listOfDamage.Add(dragonsCollection[type][name][Health]);
            }

        }
        //    averageDamage = listOfDamage.Average();

        //    var listOfHealth = new List<int>(dragonsCollection[type].Values.Count);
        //    foreach (var name in dragonsCollection[type].Keys)
        //    {
        //        listOfHealth.Add(dragonsCollection[type][name][1]);
        //    }
        //    averageHealth = listOfHealth.Average();

        //    var listOfArmor = new List<int>(dragonsCollection[type].Values.Count);
        //    foreach (var name in dragonsCollection[type].Keys)
        //    {
        //        listOfArmor.Add(dragonsCollection[type][name][2]);
        //    }
        //    averageArmor = listOfArmor.Average();

        //    Console.WriteLine($"{type}::({averageDamage:f2}/{averageHealth:f2}/{averageArmor:f2})");

        //    foreach (var dragon in dragonsCollection[type].OrderBy(x => x.Key))
        //    {
        //        Console.WriteLine($"-{dragon.Key} -> damage: {dragonsCollection[type][dragon].z}, health: {dragon.Value[1]}, armor: {dragon.Value[2]}");
        //    }
        //}


        //foreach (var type in dragonsCollection.Keys)
        //{
        //    Console.WriteLine($"{type}::({dragonsCollection[type].Values}/{}/{})");
        //}
    }
}