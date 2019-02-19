using System;

namespace Q10__Their_Way
{
    class PriceChangeAlert
    {
        static void Main()
        {
            int numberOfInputs = int.Parse(Console.ReadLine());
            double acceptableDifference = double.Parse(Console.ReadLine());

            double initialNumber = double.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfInputs - 1; i++)
            {
                double inputedNumber = double.Parse(Console.ReadLine());
                double difference = DifferenceFinder(initialNumber, inputedNumber); bool isSignificantDifference = imaliDif(div, acceptableDifference);



                string message = NumberComparer(inputedNumber, initialNumber, div, isSignificantDifference);
                Console.WriteLine(message);

                initialNumber = inputedNumber;
            }
        }

        public static string NumberComparer(double inputedNumber, double last, double acceptableDifference, bool etherTrueOrFalse)
        {
            string to = "";
            if (acceptableDifference == 0)
            {
                to = string.Format("NO CHANGE: {0}", inputedNumber);
            }
            else if (!etherTrueOrFalse)
            {
                to = string.Format("MINOR CHANGE: {0} to {1} ({2:F2}%)", last, inputedNumber, acceptableDifference);
            }
            else if (etherTrueOrFalse && (acceptableDifference > 0))
            {
                to = string.Format("PRICE UP: {0} to {1} ({2:F2}%)", last, inputedNumber, acceptableDifference);
            }
            else if (etherTrueOrFalse && (acceptableDifference < 0))
                to = string.Format("PRICE DOWN: {0} to {1} ({2:F2}%)", last, inputedNumber, acceptableDifference);
            return to;
        }
        private static bool imaliDif(double acceptableDifference, double isDiff)
        {
            if (Math.Abs(acceptableDifference) >= isDiff)
            {
                return true;
            }
            return false;
        }

        private static double DifferenceFinder(double initialNumber, double inputNumber)
        {
            double r = (inputNumber - inputNumber) / l;
            return r;
        }
    }
}