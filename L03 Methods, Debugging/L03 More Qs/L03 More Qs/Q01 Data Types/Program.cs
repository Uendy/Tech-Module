using System;

public class Program
{
    public static void Main()
    {
        string dataType = Console.ReadLine();

        switch (dataType)
        {
            case "int":
                int inputNumber = int.Parse(Console.ReadLine());
                Console.WriteLine(IntModifier(inputNumber));
                break;

            case "real":
                double inputDecimal = double.Parse(Console.ReadLine());
                inputDecimal = DoubleModifier(inputDecimal);
                inputDecimal.ToString();
                Console.WriteLine($"{inputDecimal:f2}");
                break;

            case "string":
                string inputString = Console.ReadLine();
                Console.WriteLine(StringModifier(inputString));
                break;
        }
    }

    static int IntModifier(int inputNumber)
    {
        return inputNumber * 2;
    }

    static double DoubleModifier (double inputDecimal)
    {
        inputDecimal *= 1.5;
        return Math.Round(inputDecimal, 2);
    }

    static string StringModifier(string inputString)
    {
        inputString = '$' + inputString;
        inputString = inputString + '$';
        return inputString;
    }
}
