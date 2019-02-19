using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var listOfStudents = new List<Student>();

        int numberOfInputs = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfInputs; i++)
        {
            var input = Console.ReadLine()
                .Split(' ')
                .ToArray();

            string name = input[0];

            var listOfGrades = new List<double>();
            for (int indexOfInput = 1; indexOfInput < input.Length; indexOfInput++)
            {
                listOfGrades.Add(double.Parse(input[indexOfInput]));
            }

            var student = new Student
            {
                Name = name,
                Grades = listOfGrades
            };

            bool aboveFive = student.Average >= 5.00;
            if (aboveFive == true)
            {
                listOfStudents.Add(student);
            }
        }

        var resultList = listOfStudents
            .OrderBy(student => student.Name)
            .ThenByDescending(student => student.Average)
            .ToList();

        foreach (var student in resultList)
        {
            Console.WriteLine($"{student.Name} -> {student.Average:f2}");
        }

    }
}
