using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace Q10_Student_Groups
{
    public class Program
    {
        static void Main(string[] args)
        {
            var listOfTowns = new List<Town>();
            string[] formats = { "dd-MMM-yyyy", "d-MMM-yyyy" };

            string input = Console.ReadLine();
            while (input != "End")
            {
                bool newTown = input.Contains("=>");
                if (newTown == true)
                {
                    var inputTokens = input.Split(new string[] { "=>" }, StringSplitOptions.RemoveEmptyEntries);  // splits townName from seatSize
                                                                                                              
                    string townName = inputTokens[0].Trim();
                    var splitInputTokens = inputTokens[1].Split(' ').ToArray(); // since it gives me a whole string of "int seat"
                    int numberOfSeats = int.Parse(splitInputTokens[1]);

                    var currentTown = new Town();
                    currentTown.Name = townName;
                    currentTown.SeatCount = numberOfSeats;
                    currentTown.SeatsTaken = 0;
                    currentTown.ListOfStudents = new List<Student>();

                    listOfTowns.Add(currentTown);
                }
                else // studentInfo
                {
                    var inputTokens = input
                        .Split('|')
                        .ToArray();

                    string studentName = inputTokens[0].Trim();
                    string email = inputTokens[1].Trim();
                    var registryDate = DateTime.ParseExact(inputTokens[2].Trim(), formats, CultureInfo.InvariantCulture, DateTimeStyles.None);

                    var student = new Student();
                    student.Name = studentName;
                    student.Email = email;
                    student.RegirstrationDate = registryDate;

                    var currentTown = listOfTowns.Last();
                    currentTown.ListOfStudents.Add(student);
                    currentTown.SeatsTaken++;
                }

                input = Console.ReadLine();
            }

            int numberOfGroups = 0;
            foreach (var town in listOfTowns)
            {
                // sorting the listOfStudent
                town.ListOfStudents = town.ListOfStudents
                    .OrderBy(student => student.RegirstrationDate)
                    .ThenBy(student => student.Name)
                    .ThenBy(student => student.Email)
                    .ToList();

                // getting the numberOfGroups
                double intermediateNumber = (double)town.SeatsTaken / town.SeatCount;
                var groupsNeeded = Math.Ceiling(intermediateNumber);
                numberOfGroups += (int)groupsNeeded;

                town.ListOfGroups = new List<Group>();

                for (int indexOfGroup = 0; indexOfGroup < groupsNeeded; indexOfGroup++)
                {

                    var currentGroup = new Group();
                    currentGroup.Town = town;
                    currentGroup.ListOfStudents = new List<Student>();

                    town.ListOfGroups.Add(currentGroup);
                }
            }
            Console.WriteLine($"Created {numberOfGroups} groups in {listOfTowns.Count} towns:");

            //Like in harryPotter with the hat that sorts into houses (groups)
            foreach (var town in listOfTowns)
            {
                int indexOfStudentSoFar = 0;
                int classSizeLimit = town.SeatCount;
                for (int indexOfGroup = 0; indexOfGroup < town.ListOfGroups.Count; indexOfGroup++)
                {
                    bool lastGroup = indexOfGroup == town.ListOfGroups.Count - 1;
                    if (lastGroup == false)
                    {
                        var currentGroup = town.ListOfGroups[indexOfGroup];
                        currentGroup.ListOfStudents = new List<Student>(classSizeLimit);
                        for (int indexOfStudent = indexOfStudentSoFar; indexOfStudent < indexOfStudentSoFar + classSizeLimit; indexOfStudent++)
                        {
                            currentGroup.ListOfStudents.Add(town.ListOfStudents[indexOfStudent]);
                        }

                        indexOfStudentSoFar += classSizeLimit;
                    }
                    else // last group
                    {
                        int remainingStudent = town.ListOfStudents.Count - indexOfStudentSoFar; 
                        for (int indexOfFinalStudent = indexOfStudentSoFar; indexOfFinalStudent < indexOfStudentSoFar + remainingStudent; indexOfFinalStudent++)
                        {
                            var currentGroup = town.ListOfGroups[indexOfGroup];
                            currentGroup.ListOfStudents.Add(town.ListOfStudents[indexOfFinalStudent]);
                        }
                    }
                }
            }

            // sorting town and output
            listOfTowns = listOfTowns.OrderBy(x => x.Name).ToList();
            foreach (var town in listOfTowns)
            {
                foreach (var group in town.ListOfGroups)
                {
                    Console.Write($"{town.Name} => ");
                    string output = string.Join(", ", group.ListOfStudents.Select(x => x.Email));
                    Console.WriteLine(output);
                }
            }
        }
    }
}
