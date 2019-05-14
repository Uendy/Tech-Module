using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
public class Program
{
    public static void Main()
    {
        //At the Software University we often organize programming courses for beginners in different towns. 
        //We usually run a registration form and after the registration finishes, we distribute the students into study groups.
        //Groups have different sizes in each town.

        //You are given a report holding the registrations for each town and the lab capacity(seats count) for each town.
        //It comes in the following format:
        //•	Town name => X seats(where X is the capacity of the training lab in this town).
        //o   Student name | student email | registration date(in format day - month - year).
        //The month name is given as 3 letters in English, e.g. “May”, “Aug” or “Nov”.
        // o The next student come after the first, etc.
        // • Then the next town and its students come, etc.
        // •The input ends by a line holding “End”.

        //The input comes in the following structure:
        //Town1 => X seats
        //       Student1 Name | student1_email@somewhere.com | day - month - year
        //       Student2 Name | student2_email@somewhere.com | day - month - year
        //       Student3 Name | student3_email@somewhere.com | day - month - year
        //…
        //Town2 => X seats
        //       Student1 Name | student1_email@somewhere.com | day - month - year
        //       Student2 Name | student2_email@somewhere.com | day - month - year
        //…
        //End

        //Your task is to create and print the study groups for each town as follows:
        //•	For each town create and print one or several study groups(depends of the number or registered students and the capacity of the lab in this town).
        //•	For each town order the students by registration date(ascending), then by name(ascending) then by email(ascending), then fill them into groups.If the students are less or equal to the lab capacity, create only one group.When the students are more than the lab capacity, distribute them in multiple groups.
        //•	Print all groups ordered by town(ascending) in the following format:
        //o   Created G groups and T towns:
        //o   Town1 => email1, email2, …
        //o	…
        //o   Town2 => email1, email2, …
        //o	…

        var towns = new List<Town>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "End")
            {
                break;
            }

            bool newTown = input.Contains("=>");
            if (newTown)
            {
                InputNewTown(input, towns);
            }
            else // new member in the same town
            {
                InputNewStudent(input, towns.Last().Students);
            }
        }
    }

    public static List<Town> InputNewTown(string input, List<Town> towns) {

        string separator = "=>";
        var inputTokens = input.Split(new string[] { separator, " "}, StringSplitOptions.RemoveEmptyEntries).ToArray();

        string townName = inputTokens[0];
        int groupSeats = int.Parse(inputTokens[1]);

        var town = new Town() {
            Name = townName,
            Size = groupSeats,
            Students = new List<Student>(),
            Groups = new List<Group>()
        };

        towns.Add(town);

        return towns;
    }

    public static List<Student> InputNewStudent(string input, List<Student> Students) {

        var inputTokens = input.Split('|').ToArray();
        string name = inputTokens[0].Trim();
        string email = inputTokens[1].Trim();

        string[] formats = { "dd-MMM-yyyy", "d-MMM-yyyy" };
        var registered = DateTime.ParseExact(inputTokens[2].Trim(), formats, CultureInfo.InvariantCulture, DateTimeStyles.None);

        var student = new Student() {
            Name = name,
            Email = email,
            RegistryDate = registered
        };

        Students.Add(student);

        return Students;
    }
}