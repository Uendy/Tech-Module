using System;
using System.Collections.Generic;
using System.Linq;

namespace Q07_Part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var BigBill = new Bill();
            BigBill.BigBillTotal = 0.0;
            int numberOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfInputs; i++)
            {
                var productsAndPrice = Console.ReadLine()
                    .Split('-')
                    .ToArray();

                string productName = productsAndPrice[0];
                double productPrice = double.Parse(productsAndPrice[1]);

                BigBill.DictOfProductAndPrice = new Dictionary<string, double>();

                bool alreadyHaveProduct = BigBill.DictOfProductAndPrice.ContainsKey(productName);
                if (alreadyHaveProduct == true)
                {
                    BigBill.DictOfProductAndPrice[productName] = productPrice;
                }
                else
                {
                    BigBill.DictOfProductAndPrice[productName] = 0.0;
                    BigBill.DictOfProductAndPrice[productName] = productPrice;
                }
            }

            BigBill.ListOfPersonalisedBills = new List<PersonalisedBill>();
            BigBill.ListOfClients = new List<string>();
            string orderInput = Console.ReadLine();
            while (orderInput != "end of clients")
            {
                var orderTokens = orderInput
                    .Split('-', ',')
                    .ToArray();

                string clientName = orderTokens[0];
                string productName = orderTokens[1];
                bool productInRegistry = BigBill.DictOfProductAndPrice.ContainsKey(productName); // skip this line if not in reg.
                if (productInRegistry == false)
                {
                    orderInput = Console.ReadLine();
                    continue;
                }
                int productQuantity = int.Parse(orderTokens[2]);

                BigBill.ListOfClients.Add(clientName);

                var currentPersonalBill = new PersonalisedBill();
                currentPersonalBill.PersonalShoppingBasket = new Dictionary<string, Dictionary<string, int>>();
                currentPersonalBill.PersonalShoppingBasket[clientName] = new Dictionary<string, int>();
                currentPersonalBill.PersonalShoppingBasket[clientName][productName] = productQuantity;

                //currentPersonalBill.ClientName = clientName;
                //currentPersonalBill.PersonalShoppingBasket = new Dictionary<string, int>();
                //currentPersonalBill.PersonalShoppingBasket[productName] = productQuantity;
                currentPersonalBill.PersonalTotal = BigBill.DictOfProductAndPrice[productName] * productQuantity;
                BigBill.BigBillTotal += currentPersonalBill.PersonalTotal;

                BigBill.ListOfPersonalisedBills.Add(currentPersonalBill);

                orderInput = Console.ReadLine();
            }

            BigBill.ListOfPersonalisedBills.OrderBy(person => person.PersonalShoppingBasket);

            foreach (var nestedDict in BigBill.ListOfPersonalisedBills)
            {
                foreach (var person in BigBill.ListOfClients)
                {
                    Console.WriteLine($"{nestedDict.PersonalShoppingBasket[person]}");
                    Console.WriteLine($"-- {nestedDict.PersonalShoppingBasket.Keys} - {nestedDict.PersonalShoppingBasket.Values}");
                    Console.WriteLine($"{nestedDict.PersonalTotal:f2}");
                }
            }
            Console.WriteLine($"{BigBill.BigBillTotal:f2}");
        }
    }
}
