using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Define a class Student, which holds the following information about students:
        //name, list of grades and average grade (calculated property, read-only).
        //A single grade will be in range [2…6], e.g. 3.25 or 5.50.

        //Read a list of students and print the students that have average grade ≥ 5.00 ordered by name(ascending),
        //then by average grade(descending). Print the student name and the calculated average grade.
        var listOfStudents = new List<Student>();

        int numberOfStudents = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfStudents; i++)
        {
            var currentStudent = new Student();

            var studentInfo = Console.ReadLine().Split(' ').ToList();

            currentStudent.Name = studentInfo[0]; // take the name and remove it leaving only the grades
            studentInfo.Remove(studentInfo[0]);

            var studentGrades = studentInfo.Select(double.Parse).ToList(); // convert grades to double

            currentStudent.Grades = new List<double>();
            foreach (var grade in studentGrades)
            {
                currentStudent.Grades.Add(grade);
            }

            bool aboveFive = currentStudent.AverageGrade >= 5.00; //sift for the Отличници
            if (aboveFive)
            {
                listOfStudents.Add(currentStudent);
            }
        }

        listOfStudents = listOfStudents.OrderBy(x => x.Name).ThenByDescending(x => x.AverageGrade).ToList(); //ordering

        //Pringint
        foreach (var student in listOfStudents)
        {
            Console.WriteLine($"{student.Name} -> {student.AverageGrade:f2}");
        }
    }
}