using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Write a class Sale holding the following data: town, product, price, quantity.
        //Read a list of sales and calculate and print the total sales by town as shown in the output.
        //Order alphabetically the towns in the output.

        var townAndProfit = new SortedDictionary<string, double>();

        int numberOfInputs = int.Parse(Console.ReadLine());
        for (int input = 0; input < numberOfInputs; input++)
        {
            //reading and putting data into Object
            var inputTokens = Console.ReadLine().Split(' ').ToList();
            var currentSale = new Sale()
            {
                Town = inputTokens[0],
                Product = inputTokens[1],
                Price = double.Parse(inputTokens[2]),
                Quantity = double.Parse(inputTokens[3])
            };

            //inputing data into Dictionary
            bool newTown = !townAndProfit.ContainsKey(currentSale.Town);
            if (newTown)
            {
                townAndProfit[currentSale.Town] = currentSale.Total;
            }
            else
            {
                townAndProfit[currentSale.Town] += currentSale.Total;
            }
        }

        //printing
        foreach (var town in townAndProfit.Keys)
        {
            Console.WriteLine($"{town} -> {townAndProfit[town]:f2}");
        }
    }
}