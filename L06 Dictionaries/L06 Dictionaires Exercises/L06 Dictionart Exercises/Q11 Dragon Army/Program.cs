using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q11_Dragon_Army
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfDragos = int.Parse(Console.ReadLine());

            var dict = new Dictionary<string, Dictionary<string, List<int>>>();
            // key = type
            // value = innerDict
            // => InnerDict key = name 
            // => InnerDict valye = List of stats (value[0] = dmg, value[1] = hp, value[2] = armor)

            for (int dragonIndex = 0; dragonIndex < numberOfDragos; dragonIndex++)
            {
                string input = Console.ReadLine();
                string[] inputTokens = input
                    .Split(' ')
                    .ToArray();

                string type = inputTokens[0]; // check if type and name are capital letters
                string name = inputTokens[1];
                

                int damage = 0;
                int health = 0;
                int armor = 0;

                var listOfNullsIndexs = new List<int>();
                bool anyNullStats = inputTokens[2] == "null" || inputTokens[3] == "null" || inputTokens[4] == "null";
                if (anyNullStats == true)
                {
                    for (int index = 2; index < 5; index++)
                    {
                        if (inputTokens[index] == "null")
                        {
                            listOfNullsIndexs.Add(index);
                        }
                    }

                    foreach (var itemIndex in listOfNullsIndexs)
                    {
                        switch (itemIndex)
                        {
                            case 2:
                                damage = 45;
                                break;
                            case 3:
                                health = 250;
                                break;
                            case 4:
                                armor = 10;
                                break;
                        }
                    }

                    if (damage == 0)
                    {
                        damage = int.Parse(inputTokens[2]);
                    }
                    if (health == 0)
                    {
                        health = int.Parse(inputTokens[3]);
                    }
                    if (armor == 0)
                    {
                        armor = int.Parse(inputTokens[4]);
                    }
                }
                else // no null values
                {
                    damage = int.Parse(inputTokens[2]);
                    health = int.Parse(inputTokens[3]);
                    armor = int.Parse(inputTokens[4]);
                }

                // have to put the inputTokens together into a dictionary
                bool newType = !dict.ContainsKey(type);
                if (newType)
                {
                    dict[type] = new Dictionary<string, List<int>>();
                    dict[type][name] = new List<int>();
                    dict[type][name].Add(damage);
                    dict[type][name].Add(health);
                    dict[type][name].Add(armor);
                }
                else // already have this type
                {
                    bool newName = !dict[type].ContainsKey(name);
                    if (newName == true)
                    {
                        dict[type][name] = new List<int>();
                        dict[type][name].Add(damage);
                        dict[type][name].Add(health);
                        dict[type][name].Add(armor);
                    }
                    else // update stats
                    {
                        dict[type][name][0] = damage;
                        dict[type][name][1] = health;
                        dict[type][name][2] = armor;
                    }
                }
            }

            // you have to aggregate, order them and print

            foreach (var item in dict.Keys)
            {
                double averageDamage = 0.0;
                double averageHealth = 0.0;
                double averageArmor = 0.0;

                var listOfDamage = new List<int>(dict[item].Values.Count);
                foreach (var innerKey in dict[item].Keys)
                {
                    listOfDamage.Add(dict[item][innerKey][0]);
                }
                averageDamage = listOfDamage.Average();

                var listOfHealth = new List<int>(dict[item].Values.Count);
                foreach (var innerKey in dict[item].Keys)
                {
                    listOfHealth.Add(dict[item][innerKey][1]);
                }
                averageHealth = listOfHealth.Average();

                var listOfArmor = new List<int>(dict[item].Values.Count);
                foreach (var innerKey in dict[item].Keys)
                {
                    listOfArmor.Add(dict[item][innerKey][2]);
                }
                averageArmor = listOfArmor.Average();

                Console.WriteLine($"{item}::({averageDamage:f2}/{averageHealth:f2}/{averageArmor:f2})");

                foreach (var dragon in dict[item].OrderBy(x => x.Key))
                {
                    Console.WriteLine($"-{dragon.Key} -> damage: {dragon.Value[0]}, health: {dragon.Value[1]}, armor: {dragon.Value[2]}");
                }
            }
        }
    }
}
