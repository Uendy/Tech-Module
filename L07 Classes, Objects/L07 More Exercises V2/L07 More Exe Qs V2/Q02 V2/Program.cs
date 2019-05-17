using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
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

        var cars = new List<Car>();
        var trucks = new List<Truck>();

        while (true) // inputing vehicles into their respective lists with their properties
        {
            string input = Console.ReadLine();
            if (input == "End")
            {
                break;
            }

            var inputTokens = input.Split(' ').ToArray();
            if (inputTokens[0].ToLower() == "car")
            {
                var car = new Car()
                {
                    Model = inputTokens[1],
                    Color = inputTokens[2],
                    Horsepower = int.Parse(inputTokens[3])
                };
                cars.Add(car);
            }
            else //truck
            {
                var truck = new Truck()
                {
                    Model = inputTokens[1],
                    Color = inputTokens[2],
                    Horsepower = int.Parse(inputTokens[3])
                };
                trucks.Add(truck);
            }
        }

        while (true) //printing models of vehicles and their properties
        {
            string input = Console.ReadLine();
            if (input == "Close the Catalogue")
            {
                break;
            }

            bool isCar = cars.Exists(x => x.Model == input);
            if (isCar)
            {
                var currentCar = cars.Find(x => x.Model == input);
                Console.WriteLine("Type: Car");
                Console.WriteLine($"Model: {currentCar.Model}");
                Console.WriteLine($"Color: {currentCar.Color}");
                Console.WriteLine($"Horsepower: {currentCar.Horsepower}");
            }
            else //is a truck
            {
                var currentTruck = trucks.Find(x => x.Model == input);
                Console.WriteLine("Type: Truck");
                Console.WriteLine($"Model: {currentTruck.Model}");
                Console.WriteLine($"Color: {currentTruck.Color}");
                Console.WriteLine($"Horsepower: {currentTruck.Horsepower}");
            }
        }

        bool carsAreEmpty = cars.Count() == 0;
        if (carsAreEmpty)
        {
            Console.WriteLine("Cars have average horsepower of: 0.00.");
        }
        else //not empty -> print the average
        {
            Console.WriteLine($"Cars have average horsepower of: {cars.Average(x => x.Horsepower):f2}.");
        }

        bool trucksAreEmpty = trucks.Count() == 0;
        if (trucksAreEmpty)
        {
            Console.WriteLine("Trucks have average horsepower of: 0.00.");
        }
        else // not empty -> print the average
        {
            Console.WriteLine($"Trucks have average horsepower of: {trucks.Average(x => x.Horsepower):f2}.");
        }
    }
}