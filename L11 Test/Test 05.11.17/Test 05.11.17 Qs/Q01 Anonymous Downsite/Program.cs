using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
public class Program
{
    public static void Main()
    {
        //link to test and to check: https://judge.softuni.bg/Contests/Practice/Index/834#0

        #region
        //        The Anonymous informal group of activists have hacked a few commercial websites and the CIA has hired you to write a software which calculates the losses. Based on the given data, use the appropiate data types.
        //You will receive 2 input lines – each containing an integer. 
        //•	The first is N – the number of websites which are down.
        //•	The second is the security key.
        //On the next N lines you will receive data about websites in the following format:
        //        { siteName}
        //        { siteVisits}
        //        { siteCommercialPricePerVisit}
        //        You must calculate the site loss by the following formula: siteVisits* siteCommercialPricePerVisit
        //When you finish reading all data, you must print the affected sites’ names – each on a new line.
        //Then you must print the total money loss – sum of all site loss, on a new line.
        //Finally you must print the security token, which is the security key, POWERED by the COUNT of affected sites.
        //Input
        //•	On the first input line you will get N – the count of affected websites.
        //•	On the second input line you will the security key.
        //•	On the next N input lines you will get data about the websites.
        //Output
        //•	As output you must print all affected websites’ names – each on a new line.
        //•	After the website names you must print the total loss of data, printed to the 20th digit after the decimal point. The format is “Total Loss: { totalLoss}”.
        //•	Finally you must print the security token.The format is “Security Token: { securityToken}”.
        #endregion

        int numberOfSites = int.Parse(Console.ReadLine());
        int securityKey = int.Parse(Console.ReadLine());

        var listOfSites = new List<string>();
        decimal totalLoss = 0;

        for (int i = 0; i < numberOfSites; i++)
        {
            var currentInput = Console.ReadLine();
            var inputTokens = currentInput.Split(' ').ToArray();

            string website = inputTokens[0];

            listOfSites.Add(website);

            long siteVisits = long.Parse(inputTokens[1]);
            decimal payPerView = decimal.Parse(inputTokens[2]);

            decimal currentLoss = siteVisits * payPerView;

            totalLoss += currentLoss;
        }

        foreach (var website in listOfSites)
        {
            Console.WriteLine(website);
        }
        Console.WriteLine($"Total Loss: {totalLoss:F20}");
        Console.WriteLine($"Security Token: {BigInteger.Pow(new BigInteger(securityKey), numberOfSites)}");
    }
}