using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    //check any question: https://judge.softuni.bg/Contests/Practice/Index/584#0
    public static void Main()
    {
        //You will receive an unknown number of lines. On each line, you will receive array with 3 elements:

        //The first element will be string and represents the name of the person. 
        //The second element will be a string and will represent the ID of the person.
        //The last element will be an integer and represents the age of the person.

        //When you receive the command “End”, stop taking input and print all the people, ordered by age. 

        var people = new List<Person>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "End")
            {
                break;
            }

            var inputTokens = input.Split(' ').ToArray();

            var person = new Person()
            {
                Name = inputTokens[0],
                ID = inputTokens[1],
                Age = int.Parse(inputTokens[2])
            };

            people.Add(person);
        }

        people = people.OrderBy(x => x.Age).ToList();

        foreach (var person in people)
        {
            Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
        }
    }
}