using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        #region
        //  Instructions: You’ve beaten all the content and the last thing left to accomplish is own a legendary item. However, it’s a tedious process and requires quite a bit of farming. Anyway, you are not too pretentious – any legendary will do. The possible items are:
        // •	Shadowmourne – requires 250 Shards;
        // •	Valanyr – requires 250 Fragments;
        // •	Dragonwrath – requires 250 Motes;
        // Shards, Fragments and Motes are the key materials, all else is junk.You will be given lines of input, such as
        // 2 motes 3 ores 15 stones.Keep track of the key materials -the first that reaches the 250 mark wins the race. At that point, print the corresponding legendary obtained.Then, print the remaining shards, fragments, motes, ordered by quantity in descending order, then by name in ascending order, each on a new line.Finally, print the collected junk items, in alphabetical order.

        // Input
        // •	Each line of input is in format { quantity}{ material}{ quantity}{ material} … { quantity}{ material}

        // Output
        // •	On the first line, print the obtained item in format { Legendary item} obtained!
        // •	On the next three lines, print the remaining key materials in descending order by quantity
        // o If two key materials have the same quantity, print them in alphabetical order
        // •	On the final several lines, print the junk items in alphabetical order
        // o All materials are printed in format { material}: { quantity}
        //         o All output should be lowercase, except the first letter of the legendary

        // Example: 
        //              Input                                   Output
        // 123 silver 6 shards 8 shards 5 motes         Dragonwrath obtained!
        // 9 fangs 75 motes 103 MOTES 8 Shards              shards: 22
        // 86 Motes 7 stones 19 silver                      motes: 19
        //                                                  fragments: 0
        //                                                  fangs: 9
        //                                                  silver: 123


        #endregion

        // Initialize dict:
        var items = new Dictionary<string, int>(); // key = item, value = amount

        // Add legendaryTokens:
        items["shards"] = 0;
        items["motes"] = 0;
        items["fragments"] = 0;

        // Reading input:
        bool legendaryAchieved = items["shards"] > 250 || items["motes"] > 250 || items["fragments"] > 250;
        while (!legendaryAchieved)
        {
            string input = Console.ReadLine().ToLower();

            // sort items:
            var itemTokens = input.Split(' ').ToList();
            for (int i = 0; i < itemTokens.Count(); i+=2) // see if this gives an error
            {
                int amount = int.Parse(itemTokens[i]);
                string item = itemTokens[i + 1];

                bool newItem = !items.ContainsKey(item);
                if(newItem)
                {
                    items[item] = 0;
                }
                items[item] += amount;

                // Need to stop accepting items after achieving legendary
                if(items["shards"] > 250 || items["motes"] > 250 || items["fragments"] > 250)
                {
                    return;
                }
            }

            // Check and see if you need to keep going:
            legendaryAchieved = items["shards"] > 250 || items["motes"] > 250 || items["fragments"] > 250;
        }

        // print legendary obtained
        if (items["shards"] > 250)
        {
            Console.WriteLine("Shadowmourne obtained!");
            items["shards"] -= 250;
        }
        else if (items["motes"] > 250)
        {
            Console.WriteLine("Dragonwrath obtained!");
            items["motes"] -= 250;
        }
        else // fragments
        {
            Console.WriteLine("Valanyr obtained!");
            items["fragments"] -= 250;
        }

        // order remaining items and print
    }
}