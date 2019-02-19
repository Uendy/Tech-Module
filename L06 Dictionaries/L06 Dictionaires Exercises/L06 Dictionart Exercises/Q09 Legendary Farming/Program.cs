using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q09_Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            var legendaryMaterials = new Dictionary<string, int>();
            legendaryMaterials["shards"] = 0;
            legendaryMaterials["fragments"] = 0;
            legendaryMaterials["motes"] = 0;

            var commonMaterials = new SortedDictionary<string, int>();

            var input = Console.ReadLine();

            while (true)
            {
                var lootDrop = input
                    .Split(' ')
                    .ToList();

                for (int index = 0; index < lootDrop.Count; index+=2) // itterate over 2
                {
                    int quantity = 0;
                    string material = "";

                    quantity = int.Parse(lootDrop[index]);
                    material = lootDrop[index + 1].ToLower();

                    bool legendaryLoot = legendaryMaterials.ContainsKey(material);
                    if (legendaryLoot == true)
                    {
                        legendaryMaterials[material] += quantity;
                        bool over250 = legendaryMaterials[material] >= 250;
                        if (over250 == true)
                        {
                            ProjectComplete(legendaryMaterials, commonMaterials);
                        }
                    }
                    else
                    {
                        bool alreadyContainsMaterial = commonMaterials.ContainsKey(material);
                        if (alreadyContainsMaterial == true)
                        {
                            commonMaterials[material] += quantity;
                        }
                        else // new common
                        {
                            commonMaterials[material] = 0;
                            commonMaterials[material] += quantity;
                        }
                    }
                }
                input = Console.ReadLine();
            }

        }
        static void ProjectComplete(Dictionary <string, int> legendaryMaterials, SortedDictionary<string, int> commonMaterials)
        {
            string materialCollected = "";
            foreach (var item in legendaryMaterials)
            {
                bool over250 = item.Value >= 250;
                if (over250 == true)
                {
                    materialCollected = item.Key;
                    legendaryMaterials[item.Key] -= 250;
                    break;
                }
            }

            switch (materialCollected)
            {
                case "shards":
                    Console.WriteLine("Shadowmourne obtained!");
                    break;
                case "fragments":
                    Console.WriteLine("Valanyr obtained!");
                    break;
                case "motes":
                    Console.WriteLine("Dragonwrath obtained!");
                    break;
            }

            legendaryMaterials = legendaryMaterials.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value); // orders by quantity
            // you need to find a way to compare the legendary.Values and if two are the same => alphabetical notation

            foreach (var item in legendaryMaterials.Keys)
            {
                    Console.WriteLine($"{item}: {legendaryMaterials[item]}");
            }

            foreach (var item in commonMaterials)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            Environment.Exit(0);
        }
    }
}
