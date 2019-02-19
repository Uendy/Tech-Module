using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var DictOfProducts = new Dictionary<string, double>();

        int numberOfInputs = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfInputs; i++)
        {
            var invertory = Console.ReadLine().Split('-').ToArray();

            bool alreadyInRegistry = DictOfProducts.ContainsKey(invertory[0]);
            if (alreadyInRegistry == true)
            {
                DictOfProducts[invertory[0]] = double.Parse(invertory[1]);
            }
            else // new product
            {
                DictOfProducts.Add(invertory[0], double.Parse(invertory[1]));
            }
        }

        var listOfClients = new List<Customer>();

        string orderAsInput = Console.ReadLine();
        while (orderAsInput != "end of clients")
        {
            var orderTokens = orderAsInput
                .Split('-', ',')
                .ToArray();

            string name = orderTokens[0];
            string product = orderTokens[1];
            int quantity = int.Parse(orderTokens[2]);


            bool productInStock = DictOfProducts.ContainsKey(product);
            if (productInStock == true)
            {
                Customer client = new Customer()
                {
                    Name = name,
                    PersonalDict = new Dictionary<string, int>
                    {
                        [product] = quantity
                    },
                    PersonalTotal = quantity * DictOfProducts[product]

                };

                if (!listOfClients.Exists(c => c.Name == client.Name))
                {
                    listOfClients.Add(client);
                }
                else
                {
                    Customer existingCustomer = listOfClients.First(c => c.Name == name);
                    if (!(existingCustomer.PersonalDict.ContainsKey(product)))
                    {
                        existingCustomer.PersonalDict.Add(product, quantity);
                        existingCustomer.PersonalTotal += client.PersonalTotal;
                    }
                    else
                    {
                        existingCustomer.PersonalDict[product] += quantity;
                        existingCustomer.PersonalTotal += client.PersonalTotal;
                    }
                }

            }


            orderAsInput = Console.ReadLine();
        }

        double totalBill = 0.0;
        var orderedListOfClients = listOfClients.OrderBy(client => client.Name).ThenBy(b => b.PersonalTotal).ToList();
        foreach (var client in orderedListOfClients)
        {
            Console.WriteLine($"{client.Name}");
            foreach (var product in client.PersonalDict)
            {
                Console.WriteLine($"-- {product.Key} - {product.Value}");
            }
            Console.WriteLine($"Bill: {client.PersonalTotal:f2}");
            totalBill += client.PersonalTotal;
        }
        Console.WriteLine($"Total bill: {totalBill:f2}");
    }
}
