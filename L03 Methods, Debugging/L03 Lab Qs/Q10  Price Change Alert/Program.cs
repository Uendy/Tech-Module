using System;

namespace Q10__Price_Change_Alert
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputedNumbers = int.Parse(Console.ReadLine());

            double acceptableDifference = double.Parse(Console.ReadLine());

            StackOfNumber(numberOfInputedNumbers, acceptableDifference);
        }

        static void StackOfNumber(int numberOfInputedNumbers, double acceptableDifference)
        {
            double initialNumber = double.Parse(Console.ReadLine()); ////taking the first price

            for (int number = 1; number <= numberOfInputedNumbers-1; number++)
            {
               double comparisonNumber = double.Parse(Console.ReadLine()); //// second price 

                Console.WriteLine(DifferenceCalculator(initialNumber, comparisonNumber, acceptableDifference));

                initialNumber = comparisonNumber;
            }
        }

        static string DifferenceCalculator(double initialNumber, double comparisonNumber, double acceptableDifference)
        {
            if (initialNumber > comparisonNumber)
            {
                var difference = initialNumber - comparisonNumber;

                if (difference >= acceptableDifference * comparisonNumber) //// Major Change
                {
                    double percentDownMajor = difference / initialNumber * 100;
                    return $"PRICE DOWN: {initialNumber} to {comparisonNumber} ({percentDownMajor:F2}%)";
                }
                else //// Minor Change
                {
                    double percentDownMinor = difference / initialNumber * 100;
                    return $"MINOR CHANGE: {initialNumber} to {comparisonNumber} ({percentDownMinor:F2}%)";
                }
            }
            else if (initialNumber == comparisonNumber)
            {
                return ($"NO CHANGE: {initialNumber}");
            }
            else //// comparison >= initial
            {
                var difference = comparisonNumber - initialNumber;

                if (difference >= acceptableDifference * initialNumber) ////Major Change
                {
                    double percentUpMajor = difference / initialNumber * 100;
                    return $"PRICE UP: {initialNumber} to {comparisonNumber} ({percentUpMajor:F2}%)";
                }
                else ////Minor Change
                {
                    double percentUpMinor = difference / initialNumber * 100;
                    return $"MINOR CHANGE: {initialNumber} to {comparisonNumber} ({percentUpMinor:F2}%)";
                }
            }
        }
    }
}
