using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

public class Program
{
    static void Main(string[] args)
    {
        var dictOfStudents = new SortedDictionary<string, Student>();

        var inputNameAndDate = Console.ReadLine();
        while (inputNameAndDate != "end of dates")
        {
            var inputTokens = inputNameAndDate
                .Split(' ', ',')
                .ToList();
            var userName = inputTokens[0];

            var currentStudent = new Student(); //  ако някой лектор е подаден два пъти, втория запис затрива датите от първия запис. Никъде не проверявате дали имате вече такъв лектор.
            currentStudent.StudentName = userName;
            currentStudent.AttendingDates = new List<DateTime>();

            int numberOfDates = inputTokens.Count();
            for (int index = 1; index < numberOfDates; index++)
            {
                currentStudent.AttendingDates.Add(DateTime.ParseExact(inputTokens[index], "dd/MM/yyyy", CultureInfo.InvariantCulture));
            }

            dictOfStudents[userName] = currentStudent;

            inputNameAndDate = Console.ReadLine();
        }

        // comment section
        string comment = Console.ReadLine();
        while (comment != "end of comments")
        {
            var commentTokens = comment.Split('-').ToArray();
            string userName = commentTokens[0];

            bool dictContainsUserName = dictOfStudents.ContainsKey(userName);
            if (dictContainsUserName == false)
            {
                comment = Console.ReadLine();
                continue;
            }
            else // it does exist
            {
                var currentStudent = dictOfStudents[userName];

                bool alreadyHaveComments = currentStudent.Comment != null;
                if (alreadyHaveComments == true)
                {
                        currentStudent.Comment.Add(commentTokens[1]);
                }
                else
                {
                    currentStudent.Comment = new List<string>();
                    currentStudent.Comment.Add(commentTokens[1]);
                }
            }


            comment = Console.ReadLine();
        }

        // sorting Dates and printing
        foreach (var student in dictOfStudents.Keys)
        {
            var currentStudent = dictOfStudents[student];

            Console.WriteLine(currentStudent.StudentName);
            Console.WriteLine("Comments:");
            if (currentStudent.Comment != null)
            {
                foreach (var currentComment in currentStudent.Comment)
                {
                    Console.WriteLine($"- {currentComment}");
                }
            }

            Console.WriteLine("Dates attended:");
            foreach (var date in currentStudent.AttendingDates.OrderBy(x => x))
            {
                Console.WriteLine($"-- {date:dd/MM/yyyy}");
            }
        }
    }
}
