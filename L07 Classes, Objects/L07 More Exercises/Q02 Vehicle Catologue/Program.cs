using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        var listOfCars = new List<Car>();
        var listOfTrucks = new List<Truck>();
        double averageCarHp = 0.00;
        double averageTruckHp = 0.00;

        string input = Console.ReadLine();
        while (input != "End")
        {
            var inputParts = input
                .Split(' ')
                .ToArray();

            string type = inputParts[0].ToLower();
            string model = inputParts[1];
            string colour = inputParts[2];
            int horsePower = int.Parse(inputParts[3]);

            if (type == "car")
            {
                var car = new Car
                {
                    Model = model,
                    Colour = colour,
                    HorsePower = horsePower
                };

                listOfCars.Add(car);
                averageCarHp += car.HorsePower;
            }
            else // truck
            {
                var truck = new Truck
                {
                    Model = model,
                    Colour = colour,
                    HorsePower = horsePower
                };
                listOfTrucks.Add(truck);
                averageTruckHp += truck.HorsePower;
            }

            input = Console.ReadLine();
        }

        string secondInput = Console.ReadLine();
        while (secondInput != "Close the Catalogue")
        {
            CarOrTruck(secondInput, listOfCars, listOfTrucks);
            secondInput = Console.ReadLine();
        }

        // have a problem with NaN if they are equal to 0.00 and I try to round them to 2;
        if (averageCarHp == 0.00)
        {
            Console.WriteLine($"Cars have average horsepower of: {averageCarHp:f2}.");
        }
        else
        {
            averageCarHp = Math.Round(averageCarHp / listOfCars.Count, 2);
            Console.WriteLine($"Cars have average horsepower of: {averageCarHp:f2}.");
        }

        if (averageTruckHp == 0.00)
        {
            Console.WriteLine($"Trucks have average horsepower of: {averageTruckHp:f2}.");
        }
        else
        {
            averageTruckHp = Math.Round(averageTruckHp / listOfTrucks.Count, 2);
            Console.WriteLine($"Trucks have average horsepower of: {averageTruckHp:f2}.");
        }
       
    }

    static void CarOrTruck(string secondInput, List<Car> listOfCars, List<Truck> listOfTrucks)
    {
        bool isACar = false;
        foreach (var car in listOfCars)
        {
            bool matchingModel = car.Model == secondInput;
            if (matchingModel == true)
            {
                isACar = true;
                Console.WriteLine("Type: Car");
                Console.WriteLine($"Model: {secondInput}");
                Console.WriteLine($"Color: {car.Colour}");
                Console.WriteLine($"Horsepower: {car.HorsePower}");
                break;
            }
        }
        if (isACar == false)
        {
            foreach (var truck in listOfTrucks)
            {
                bool matchingModel = truck.Model == secondInput;
                if (matchingModel == true)
                {
                    Console.WriteLine("Type: Truck");
                    Console.WriteLine($"Model: {secondInput}");
                    Console.WriteLine($"Color: {truck.Colour}");
                    Console.WriteLine($"Horsepower: {truck.HorsePower}");
                    break;
                }
            }
        }
    }
}

