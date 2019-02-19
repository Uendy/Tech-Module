using System;

class LongerLine
{
    static void Main()
    {
        var sizeOfSide = double.Parse(Console.ReadLine());
        string desiredOutput = Console.ReadLine().ToLower();

        switch (desiredOutput)
        {
            case "volume":
                Console.WriteLine($"{VolumeCalculator(sizeOfSide):f2}");
                break;
            case "area":
                Console.WriteLine($"{AreaCalculator(sizeOfSide):f2}");
                break;
            case "face":
                Console.WriteLine($"{FaceCalculator(sizeOfSide):f2}");
                break;
            case "space":
                Console.WriteLine($"{SpaceCalculator(sizeOfSide):f2}");
                break;
            default:
                Console.WriteLine("Error in string input");
                break;
        }
    }

    static double VolumeCalculator(double sizeOfSide)
    {
        double volume = Math.Pow(sizeOfSide, 3);
        return volume;
    }

    static double AreaCalculator(double sizeOfSide)
    {
        double area = (6 * sizeOfSide*sizeOfSide);
        return area;
    }

    static double FaceCalculator(double sizeOfSide)
    {
        double face = Math.Sqrt(2 * Math.Pow(sizeOfSide, 2));
        return face;
    }

    static double SpaceCalculator(double sizeOfSide)
    {
        double space = (Math.Sqrt(3 * Math.Pow(sizeOfSide,2)));
        return space;
    }

}