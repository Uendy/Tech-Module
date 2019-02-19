using System;
using System.Collections.Generic;
using System.Linq;

namespace Q07_Andrey_and_Billiard
{
    public class Program
    {
        static void Main(string[] args)
        {
            var currentProduct = new Bill();

            int numberOfInputs = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfInputs; i++)
            {
                var product = Console.ReadLine()
                    .Split('-')
                    .ToArray();

                currentProduct.DictOfProducts = new Dictionary<string, double>();

                bool productAlreadyInDict = currentProduct.DictOfProducts.ContainsKey(product[0]);
                if (productAlreadyInDict == false)
                {
                    currentProduct.DictOfProducts[product[0]] = 0.0;
                    currentProduct.DictOfProducts[product[0]] = double.Parse(product[1]);
                }
                else
                {
                    currentProduct.DictOfProducts[product[0]] = double.Parse(product[1]); 
                }

            }

            var listOfBills = new List<Bill>();

            var order = Console.ReadLine();
            while (order != "end of clients")
            {
                var orderTokens = order.Split('-', ',')
                    .ToArray();

                var currentBill = new Bill();
                currentBill.ClientName = orderTokens[0];
                currentBill.ProductName = orderTokens[1];
                currentBill.NumberOfProducts = int.Parse(orderTokens[2]);

                if (currentProduct.DictOfProducts.ContainsKey(currentBill.ProductName))
                {
                    listOfBills.Add(currentBill);
                }

                order = Console.ReadLine();
            }

            double totalBill = 0.0;
            foreach (var item in listOfBills)
            {
                item.ReturnOrder();
                totalBill += item.CurrentTotalBill;
            }
            Console.WriteLine(totalBill);
        }
    }
}
