using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //You’ve beaten all the content and the last thing left to accomplish is own a legendary item. 
        //However, it’s a tedious process and requires quite a bit of farming. 
        //Anyway, you are not too pretentious – any legendary will do. The possible items are:
        //•	Shadowmourne – requires 250 Shards;
        //•	Valanyr – requires 250 Fragments;
        //•	Dragonwrath – requires 250 Motes;

        //Shards, Fragments and Motes are the key materials, all else is junk.You will be given lines of input, such as
        //2 motes 3 ores 15 stones.Keep track of the key materials -the first that reaches the 250 mark wins the race.
        //At that point, print the corresponding legendary obtained.
        //Then, print the remaining shards, fragments, motes, ordered by quantity in descending order,
        //then by name in ascending order, each on a new line.Finally, print the collected junk items, in alphabetical order.

        var legendaryMaterials = new Dictionary<string, int>();
        legendaryMaterials["shards"] = 0;
        legendaryMaterials["motes"] = 0;
        legendaryMaterials["fragments"] = 0;

        var legendaryItem = new Dictionary<string, string>();
        legendaryItem["shards"] = "Shadowmourne";
        legendaryItem["fragments"] = "Valanyr";
        legendaryItem["motes"] = "Dragonwrath";

        var junkMaterials = new SortedDictionary<string, int>();

        while (true)
        {
            var collectedLoot = Console.ReadLine().ToLower().Split(' ').ToArray();
            var listOfLoot = new List<string>();

            for (int i = 0; i < collectedLoot.Count(); i += 2)
            {
                int itemCount = int.Parse(collectedLoot[i]);
                string currentItem = collectedLoot[i + 1];

                bool itemIsLegendary = legendaryMaterials.ContainsKey(currentItem);
                if (itemIsLegendary)
                {
                    LegendaryLootLogger(legendaryMaterials, legendaryItem, junkMaterials, currentItem, itemCount);//, keepGoing);
                }
                else //junk
                {
                    JunkLootLogger(junkMaterials, currentItem, itemCount);
                }
            }
        }
    }

    public static Dictionary<string, int> LegendaryLootLogger(Dictionary<string, int> legendaryMaterial, Dictionary<string, string> legendaryItems, SortedDictionary<string, int> junkMaterials,  string currentItem, int itemCount)
    {
        legendaryMaterial[currentItem] += itemCount;

        if (legendaryMaterial[currentItem] >= 250) // end
        {
            Console.WriteLine($"{legendaryItems[currentItem]} obtained!");
            legendaryMaterial[currentItem] -= 250;
            FinalLogging(legendaryMaterial, junkMaterials);
        }
        return legendaryMaterial;
    }

    public static SortedDictionary<string, int> JunkLootLogger(SortedDictionary<string, int> junkMaterials, string currentItem, int itemCount)
    {
        bool newItem = !junkMaterials.ContainsKey(currentItem);
        if (newItem)
        {
            junkMaterials[currentItem] = itemCount;
        }
        else //add to old one
        {
            junkMaterials[currentItem] += itemCount;
        } 

        return junkMaterials;
    }

    public static void FinalLogging(Dictionary<string, int> legendaryMaterials, SortedDictionary<string, int> junkMaterials)
    {
        legendaryMaterials = legendaryMaterials
            .OrderByDescending(x => x.Value).ThenBy(x => x.Key)
            .ToDictionary(x => x.Key, y => y.Value);
        foreach (var legendaryItem in legendaryMaterials.Keys)
        {
            Console.WriteLine($"{legendaryItem}: {legendaryMaterials[legendaryItem]}");
        }

        foreach (var junk in junkMaterials.Keys)
        {
            Console.WriteLine($"{junk}: {junkMaterials[junk]}");
        }
        Environment.Exit(0);
    }
}