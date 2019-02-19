using System;
using System.Collections.Generic;
using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {
        var listOfPeople = new List<Person>();

            string input = Console.ReadLine();
            while (input != "End")
            {
                var inputParts = input.Split(' ').ToArray();

                var person = new Person();
                person.Name = inputParts[0];
                person.ID = inputParts[1];
                person.Age = int.Parse(inputParts[2]);

                listOfPeople.Add(person);

                input = Console.ReadLine();
            }

            var resultList = listOfPeople.OrderBy(Person => Person.Age);

            foreach (var person in resultList)
            {
                Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
            }
        }
    }
