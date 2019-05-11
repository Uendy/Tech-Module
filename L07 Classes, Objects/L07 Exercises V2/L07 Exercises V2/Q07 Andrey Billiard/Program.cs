using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Andrey is the guy who gives us food and drinks at the game bar. He likes to play billiard. 
        //Since you are nice guy you want to help him play more of his favorite game.
        //You decide to create a program which will help him to take orders faster and generate billing information. 

        //First you will receive an integer -the amount of entities with prices(separated by "-").
        //Then you will receive a list of client.For every consumer you will receive what to buy and how much.
        //When you receive a command: "end of clients" you should display information about every client described below.
        //After that say how much total money were spent while Andrey was playing billiard.

        //Constraints:
        //-	If an entity is added more than once you should override the previous price.
        //-If buyer tries to buy an entity that is not existing - you should ignore that line.
        //-Buyers should be ordered by name ascending. 
        //-All floating point digits must be rounded to 2 digits after decimal separator.
        //-In the end of every buyer his bill should be summed.
        //-Quantity is an integer. Price – floating point.
        var menu = new Dictionary<string, double>(); // key = productName, value = valuePrice

        int numberOfProducts = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfProducts; i++)
        {
            var productInfo = Console.ReadLine().Split('-').ToArray();
            string productName = productInfo[0];
            double productPrice = double.Parse(productInfo[1]);

            menu[productName] = productPrice; // it will add it if not contained, it will override it if contained (in dict)
        }

        var listOfClients = new List<Client>();

        while (true)
        {
            string inputCommand = Console.ReadLine();
            if (inputCommand == "end of clients")
            {
                break;
            }

            var commandTokens = inputCommand.Split('-', ',').ToArray();
            string clientName = commandTokens[0];
            string productName = commandTokens[1];
            int quantity = int.Parse(commandTokens[2]);

            bool notInStore = !menu.ContainsKey(productName);
            if (notInStore)
            {
                continue;
            }

            //make the client and add all properties
            var client = new Client()
            {
                Name = clientName,
                ShoppingList = new Dictionary<string, int>
                {
                    [productName] = quantity
                },
                Bill = quantity * menu[productName]
            };

            //check if new client
            if (!listOfClients.Exists(x => x.Name == client.Name))
            {
                listOfClients.Add(client);
            }
            else
            {
                var existingCustomer = listOfClients.First(x => x.Name == clientName); //find exact Cleint
                if (!existingCustomer.ShoppingList.ContainsKey(productName)) //find if new item or not and proceed accordingly
                {
                    existingCustomer.ShoppingList.Add(productName, quantity);
                    existingCustomer.Bill += client.Bill;
                }
                else
                {
                    existingCustomer.ShoppingList[productName] += quantity;
                    existingCustomer.Bill += client.Bill;
                }
            }
        }

        double totalBill = 0.0;

        //sorting the clients and printing their tabs
        listOfClients = listOfClients.OrderBy(x => x.Name).ThenBy(x => x.Bill).ToList();
        foreach (var client in listOfClients)
        {
            Console.WriteLine(client.Name);
            foreach (var item in client.ShoppingList)
            {
                Console.WriteLine($"-- {item.Key} - {item.Value}");
                totalBill += client.Bill;
            }
            Console.WriteLine($"Bill: {client.Bill:f2}");
        }

        Console.WriteLine($"Total bill: {totalBill:f2}");
    }
}