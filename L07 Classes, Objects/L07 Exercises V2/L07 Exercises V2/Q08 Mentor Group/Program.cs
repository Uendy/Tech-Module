using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
public class Program
{
    public static void Main(string[] args)
    {
        //You are mentor of a group. You have done your job well and now you have to generate a report about your group's activity.

        //You will be given usernames and dates ("dd/MM/yyyy"), dates (if any) are separated with comma, until you receive command "end of dates". 
        //After that you will receive user and some comment (separated with dash). 
        //You can add comment for every user who is in your group (if not ignore the line). 
        //Adding comment/date to same user more than once should append to that user the comment/date.
        //Upon receiving command "end of comments" you should generate report in format:
        //{ user}
        //Comments:{ firstComment} …
        //Dates attended:
        //-- { firstDate}
        //-- { secondDate}

        //Users should be printed ordered by name(ascending).For every user dates should be sorted again in ascending order.
        //Input will be valid for in the format described - you should not check it explicitly!

        var listOfStudents = new List<Student>();

        while (true) // to add the students, names and any dates
        {
            string initialInputs = Console.ReadLine();
            if (initialInputs == "end of dates")
            {
                break;
            }

            var inputTokens = initialInputs.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string name = inputTokens[0];

            var currentStudent = new Student();

            bool newStudent = !listOfStudents.Exists(x => x.Name == name);
            if (newStudent)
            {
                currentStudent.Name = name;
                inputTokens.Remove(name); // remove the name, leaving only the dates (if any)
                currentStudent.Comments = new List<string>();
                currentStudent.DatesAttended = new List<DateTime>();
            }
            else
            {
                currentStudent = listOfStudents.First(x => x.Name == name);
            }

            if (inputTokens.Count() != 0)
            {
                while (inputTokens.Count() != 0)
                {
                    currentStudent.DatesAttended.Add(DateTime.ParseExact(inputTokens[0], "dd/MM/yyyy", CultureInfo.InvariantCulture));
                    inputTokens.RemoveAt(0);
                }
            }

            listOfStudents.Add(currentStudent);
        }

        while (true) // to add any comments
        {
            var secondInput = Console.ReadLine();
            if (secondInput == "end of comments")
            {
                break;
            }

            var inputTokens = secondInput.Split('-').ToArray(); 
            string studentName = inputTokens[0];
            string comment = inputTokens[1];

            bool studentExists = listOfStudents.Exists(x => x.Name == studentName);
            if (studentExists)
            {
                var exactStudent = listOfStudents.First(x => x.Name == studentName);
                exactStudent.Comments.Add(comment);
            }
        }

        //printing and sorting 
        foreach (var student in listOfStudents.OrderBy(x => x.Name))
        {
            Console.WriteLine(student.Name);

            Console.WriteLine("Comments:");
            if (student.Comments.Count() != 0)
            {
                foreach (var currentComment in student.Comments)
                {
                    Console.WriteLine($"- {currentComment}");
                }
            }

            Console.WriteLine("Dates attended:");
            foreach (var date in student.DatesAttended.OrderBy(x => x)) //For every user dates should be sorted again in ascending order.
            {
                string outPutDate = date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                Console.WriteLine($"-- {outPutDate}");
            }
        }

    }
}