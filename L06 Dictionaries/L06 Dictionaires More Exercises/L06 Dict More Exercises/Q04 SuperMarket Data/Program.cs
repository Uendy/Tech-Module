using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q04_SuperMarket_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            var storeCataloguePrice = new Dictionary<string, double>();
            var storeCatalogueQuantity = new Dictionary<string, int>();

            var input = Console.ReadLine()
                .Split(' ')
                .ToList();

            while (input[0] != "stocked")
            {
                string itemName = input[0];
                double price = Convert.ToDouble(input[1]);
                int quantity = Convert.ToInt32(input[2]);

                bool alreadyInStock = storeCataloguePrice.ContainsKey(itemName);
                if (alreadyInStock == false)
                {
                    storeCataloguePrice[itemName] = price;
                    storeCatalogueQuantity[itemName] = quantity;
                }
                else // already in catalogues
                {
                    bool samePrice = storeCataloguePrice[itemName] == price;
                    if (samePrice == false)
                    {
                        storeCataloguePrice[itemName] = price;
                    }

                    storeCatalogueQuantity[itemName] += quantity;
                }

                input = Console.ReadLine()
                    .Split(' ')
                    .ToList();
            }

            double grandTotalSum = 0.0D;
            foreach (var item in storeCataloguePrice.Keys)
            {
                double finalPrice; //:F2

                finalPrice = storeCataloguePrice[item] * storeCatalogueQuantity[item];
                Console.WriteLine($"{item}: ${storeCataloguePrice[item]:F2} * {storeCatalogueQuantity[item]} = ${finalPrice:F2}");
                grandTotalSum += finalPrice;
            }

            string header = new string('-', 30);
            Console.WriteLine(header);
            Console.WriteLine($"Grand Total: ${grandTotalSum:F2}");
        }
    }
}
