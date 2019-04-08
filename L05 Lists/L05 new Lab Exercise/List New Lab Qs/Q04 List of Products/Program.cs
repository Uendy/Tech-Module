using System;
using System.Collections.Generic;
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
        for (int index = 0; index < numberOfInputs; index++)
        {
            Console.WriteLine($"{index + 1}.{listOfProducts[index]}");
        }
    }
}