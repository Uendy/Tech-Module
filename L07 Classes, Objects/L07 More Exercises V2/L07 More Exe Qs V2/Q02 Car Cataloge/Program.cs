using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    //ToDo: Redo it with 2 classes for Car and Truck
    public static void Main()
    {
        //the tast:
        #region
        //You have to make a catalogue for vehicles. You will receive two types of vehicle – car or truck. 

        //Until you receive the command “End” you will receive lines of input in the format:
        //{ typeOfVehicle}{ model}{ color}{ horsepower}

        //After the “End” command, you will start receiving models of vehicles.
        //Print for every received vehicle its data in the format:
        //Type: { typeOfVehicle} 
        //Model: { modelOfVehicle}
        //Color: { colorOfVehicle}
        //Horsepower: { horsepowerOfVehicle}

        // When you receive the command “Close the Catalogue”, stop receiving input and print the average horsepower for the cars
        //and for the trucks in the format:
        //{ typeOfVehicles} have average horsepower of { averageHorsepower}.
        //The average horsepower is calculated by dividing the sum of horsepower for all vehicles
        //of the type by the total count of vehicles from the same type.
        //Format the answer to the 2nd decimal point.
        #endregion

        var cars = new List<Vehicle>();
        var trucks = new List<Vehicle>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "End")
            {
                break;
            }

            var inputTokens = input.Split(' ').ToArray();

            var vehicle = new Vehicle()
            {
                Type = inputTokens[0].ToLower(), // the input is faulty and is given as both car && Car || truck && Truck 
                Model = inputTokens[1],
                Color = inputTokens[2],
                HorsePower = int.Parse(inputTokens[3])
            };

            //add it to corresponding list
            switch (vehicle.Type)
            {
                case "car":
                    cars.Add(vehicle);
                    break;

                case "truck":
                    trucks.Add(vehicle);
                    break;
            }
        }

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "Close the Catalogue")
            {
                break;
            }

            var currentVehicle = new Vehicle();
            bool isACar = cars.Exists(x => x.Model == input);
            if (isACar)
            {
                currentVehicle = cars.Find(x => x.Model == input);
                Console.WriteLine($"Type: Car");
            }
            else // is a truck
            {
                currentVehicle = trucks.Find(x => x.Model == input);
                Console.WriteLine($"Type: Car");
            }
            Console.WriteLine($"Model: {currentVehicle.Model}");
            Console.WriteLine($"Color: {currentVehicle.Color}");
            Console.WriteLine($"Horsepower: {currentVehicle.HorsePower}");
        }

        if (cars.Count() != 0)
        {
            Console.WriteLine($"Cars have an average horsepower of: {cars.Average(x => x.HorsePower):f2}.");
        }
        else
        {
            Console.WriteLine($"Cars have an average horsepower of: {cars.Sum(x => x.HorsePower):f2}.");
        }

        if (trucks.Count() != 0)
        {
            Console.WriteLine($"Trucks have an average horsepower of: {trucks.Average(x => x.HorsePower):f2}.");
        }
        else
        {
            Console.WriteLine($"Trucks have an average horsepower of: {trucks.Sum(x => x.HorsePower):f2}.");
        }
    }
}