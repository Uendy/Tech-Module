using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        int numberOfInputs = int.Parse(Console.ReadLine());
        var dictOfTowns = new SortedDictionary<string, double>();

        for (int i = 0; i < numberOfInputs; i++)
        {
            var input = Console.ReadLine()
                .Split(' ')
                .ToArray();

            string town = input[0];
            //string product = input[1]; this one is not used
            double price = double.Parse(input[2]);
            double quantity = double.Parse(input[3]);

            bool newTown = !dictOfTowns.ContainsKey(town);
            if (newTown == true)
            {
                dictOfTowns[town] = 0.0;
            }

            var sale = new Sales
            {
                Price = price,
                Quantity = quantity
            };

            dictOfTowns[town] += sale.Total;

        }

        foreach (var item in dictOfTowns)
        {
            Console.WriteLine($"{item.Key} -> {item.Value:f2}");
        }
         
    }  
    
}

