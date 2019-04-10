using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //You will receive a list of wagons (integers) on the first line. Every integer represents the number of passengers that are currently in each of the wagons. On the next line, you will get the max capacity of each wagon (a single integer). Until you receive "end" you will be given two types of input:
        //•	Add { passengers} – add a wagon to the end with the given number of passengers.
        //•	{ passengers} -f ind an existing wagon to fit every passenger, starting from the first wagon.
        //At the end print the final state of the train(each of the wagons, separated by a space).

        var list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

        int maxCapacity = int.Parse(Console.ReadLine());

        string input = Console.ReadLine();
        while (input != "end")
        {
            var inputTokens = input.Split(' ').ToList();
            if (inputTokens[0] == "Add")
            {
                int addedWagon = int.Parse(inputTokens[1]);
                list.Add(addedWagon);
            }
            else // more passangers
            {
                int numOfPassangers = int.Parse(inputTokens[0]);
                for (int index = 0; index < list.Count(); index++)
                {
                    bool enoughSpace = list[index] + numOfPassangers <= maxCapacity;
                    if (enoughSpace == true)
                    {
                        list[index] += numOfPassangers;
                        break;
                    }
                }
            }

            input = Console.ReadLine();
        }

        string outPut = string.Join(" ", list);
        Console.WriteLine(outPut);
    }
}