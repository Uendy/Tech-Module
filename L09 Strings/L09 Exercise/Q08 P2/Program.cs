using System;
using System.Linq;

namespace Q08_P2
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            double sum = 0.0d;

            foreach (var str in input)
            {
                var stringAsCharArr = str.ToCharArray();
                var firstLetter = stringAsCharArr.First();
                var lastLetter = stringAsCharArr.Last();

                var numberAsString = string.Empty;
                for (int i = 1; i < stringAsCharArr.Count() - 1; i++)
                {
                    numberAsString += stringAsCharArr[i];
                }
                var number = double.Parse(numberAsString);

                if (firstLetter >= 65 && firstLetter <= 90) // firstLetter = Capital
                {
                    var firstLetterPosition = (firstLetter - 'A') + 1;
                    sum += number / firstLetterPosition;
                }
                else // firstLetter = lowerCase
                {
                    var firstLetterPosition = (firstLetter - 'a') + 1;
                    sum += number * firstLetterPosition;
                }

                if (lastLetter >= 65 && lastLetter <= 90)
                {
                    var lastLetterPosition = (lastLetter - 'A') + 1;
                    sum -= lastLetterPosition;
                }
                else // lastLetter = lowerCase
                {
                    var lastLetterPosition = (lastLetter - 'a') + 1;
                    sum += lastLetterPosition;
                }
            }

            Console.WriteLine($"{sum:f2}");
        }
    }
}
