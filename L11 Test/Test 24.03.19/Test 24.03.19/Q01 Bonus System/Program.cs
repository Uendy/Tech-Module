using System;
public class Program
{
    public static void Main()
    {
        // SoftUni has a bonus system for its students. The bonus is being calculated in a certain way and your task is to automatize this process.
        // Create a program that calculates bonus points for each student, for a certain course.On the first line, you are going to receive the count of the students for this course.On the second line, you will receive the count of the lectures in the course.Every course has an additional bonus.You are going to receive it on the third line.On the next lines, you will be receiving the count of attendances for each student. 
        //The bonus is calculated with the following formula:
        //{ totalBoonus} = { studentAttendances} / { courseLectures}*(5 + { additionalBonus})
        //Round the number to the nearest bigger number. Find the student with the maximum bonus and print him/ her, along with his attendances in the following format:
        //“The maximum bonus score for this course is { maxBonusPoints }. The student has attended { studentAttendances} lectures.”

        //Input / Consrtaints
        //•	On the first line you are going to receive the count of the students – an integer number in the range[0…50]
        //•	On the second line you are going to receive the count of the lectures – an integer number in the range[0...50].
        //•	On the third line you are going to receive the initial bonus – an integer number in the range[0….100].
        //•	On the next lines, you will be receiving the attendances of each student.
        //•	There will never be students with equal bonuses.

        //Output
        //•	Print the maximum bonus points along with the attendances of the given student, rounded to the nearest bigger number, scored by a student in this course in the format described above.

        int students = int.Parse(Console.ReadLine());
        int lectures = int.Parse(Console.ReadLine());
        int initialBonus = int.Parse(Console.ReadLine());

        var maxBonus = 0;
        int maxAttendance = 0;
        for (int i = 0; i < students; i++)
        {
            int attendance = int.Parse(Console.ReadLine());

            double currentStudentScore = (attendance / (double)lectures) * (5 + initialBonus);
            currentStudentScore = Math.Round(currentStudentScore); // rounded to the nearest bigger number

            bool newMax = maxBonus < currentStudentScore;
            if (newMax)
            {
                maxBonus = (int)currentStudentScore;
                maxAttendance = attendance;
            }

        }

        Console.WriteLine($"“The maximum bonus score for this course is {maxBonus}. The student has attended {maxAttendance} lectures.”");
    }
}