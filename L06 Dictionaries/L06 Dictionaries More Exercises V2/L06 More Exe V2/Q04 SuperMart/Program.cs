using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Write a program, which keeps information about products and their prices.
        //Each product has a name, a price and its quantity.
        //If the product doesn’t exist in the database yet, add it with its starting quantity.

        //If you receive a product, which already exists in the database,
        //increase its quantity by the input quantity and if its price is different, replace the price as well.

        //You will receive products’ names, prices and quantities on new lines.
        //Until you receive the command “stocked”, keep adding items to the database.
        //When you do receive the command “stocked”, print the items with their names, prices, quantities and total price of all the products with that name.
        //When you’re done printing the items, print the grand total price of all the items.

        var productAndPrice = new Dictionary<string, double>();
        var productAndQuantity = new Dictionary<string, int>();

        while (true)
        {
            string command = Console.ReadLine();
            if (command == "stocked")
            {
                break;
            }

            // recieving input
            var commandTokens = command.Split(' ').ToArray();
            var productName = commandTokens[0];
            var productPrice = double.Parse(commandTokens[1]);
            var productQuantity = int.Parse(commandTokens[2]);

            //checking if new product and updating both dictionaries
            bool newProduct = !productAndPrice.ContainsKey(productName);
            if (newProduct)
            {
                productAndPrice[productName] = productPrice;
                productAndQuantity[productName] = productQuantity;
            }
            else // already exist => update
            {
                productAndPrice[productName] = productPrice;
                productAndQuantity[productName] += productQuantity;
            }
        }

        //calculating totals and printing
        double grandTotal = 0.0;
        foreach (var productName in productAndPrice.Keys)
        {
            double currentProductTotal = productAndPrice[productName] * productAndQuantity[productName];
            grandTotal += currentProductTotal;
            Console.WriteLine($"{productName}: ${productAndPrice[productName]:f2} * {productAndQuantity[productName]} = ${currentProductTotal:f2}");
        }

        Console.WriteLine("------------------------------");
        Console.WriteLine($"Grand Total: ${grandTotal:f2}");
    }
}