using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Read a number n and n lines of products. Print a numbered list of all the products ordered by name.

        int numberOfInputs = int.Parse(Console.ReadLine());

        var listOfProducts = new List<string>();

        for (int i = 0; i < numberOfInputs; i++)
        {
            listOfProducts.Add(Console.ReadLine());
        }

        listOfProducts.Sort();
        for (int index = 1; index < numberOfInputs + 1; index++)
        {
            Console.WriteLine($"{index}.{listOfProducts[index - 1]}");
        }
    }
}