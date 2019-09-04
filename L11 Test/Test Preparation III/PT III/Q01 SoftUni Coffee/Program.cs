using System;
using System.Globalization;
public class Program
{
    public static void Main()
    {
        #region
        //At SoftUni we are placing N orders of coffee at a time, one order each month. 
        //Write a program to calculate the price for each order and the total price based on the following formula:
        //price = (daysInMonth * capsulesCount) * pricePerCapsule

        //Input / Constraints
        //•	The first line holds an integer N – the count of orders the shop will receive.
        //•	For each order the next lines hold the following information:
        //o Price per capsule – floating-point number in range[0…79, 228, 162, 514, 264, 337, 593, 543, 950, 335].
        //o Order date – in the following format: { d / M / yyyy}, e.g. 25/11/2016, 7/03/2016, 1/1/2020.
        //o Capsules count – integer in range[0…2, 147, 483, 647].
        //The input will be in the described format, there is no need to check it explicitly.

        //Output
        //The output should consist of N + 1 lines.For each order you must print a single line in the following format:
        //•	The price for the coffee is: ${ price}
        //On the last line you need to print the total price in the following format:
        //• Total: ${totalPrice}
        //The price must be rounded to 2 decimal places.
        //The total price will always be within the range [0…79,228,162,514,264,337,593,543,950,335].
        #endregion

        decimal result = 0M;
        string dateFormat = "d/M/yyyy";

        var inputs = int.Parse(Console.ReadLine());
        for (int i = 1; i <= inputs; i++)
        {
            var pricePerCapsule = decimal.Parse(Console.ReadLine());
            var date = DateTime.ParseExact(Console.ReadLine(), dateFormat, CultureInfo.InvariantCulture);
            long numberOfCapsules = long.Parse(Console.ReadLine());

            int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);

            long capsulesInMonth = daysInMonth * numberOfCapsules;

            decimal totalForMonth = capsulesInMonth * pricePerCapsule;

            result += totalForMonth;

            Console.WriteLine($"The price for the coffee is: ${totalForMonth:f2}");
        }

        Console.WriteLine($"Total: ${result:f2}");
    }
}