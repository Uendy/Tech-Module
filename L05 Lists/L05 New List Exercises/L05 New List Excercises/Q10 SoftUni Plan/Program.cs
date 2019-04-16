using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //You are tasked to help with the planning of the next Technology Fundamentals course by keeping track of the lessons
        //that are going to be included in the course, as well as all the exercises for the lessons. 

        //On the first line you will receive the initial schedule of the lessons and the exercises that are going to be a part of the next course
        //separated by comma and space ", ".But before the course starts, some changes should be made.
        //Until you receive "course start" you will be given some commands to modify the course schedule.
        //The possible commands are: 

        //Add: { lessonTitle} – add the lesson to the end of the schedule, if it does not exist.
        //Insert:{ lessonTitle}:{ index} – insert the lesson to the given index, if it does not exist.
        //Remove:{ lessonTitle} – remove the lesson, if it exists.
        //Swap:{ lessonTitle}:{ lessonTitle} – change the place of the two lessons, if they exist.
        //Exercise:{ lessonTitle} – add Exercise in the schedule right after the lesson index,
        //if the lesson exists and there is no exercise already, in the following format "{lessonTitle}-Exercise".
        //If the lesson doesn`t exist, add the lesson in the end of the course schedule, followed by the Exercise.

        //Each time you Swap or Remove a lesson, you should do the same with the Exercises, if there are any, which follow the lessons.

        string seperator = ", ";
        var course = Console.ReadLine().Split(new string[] { seperator }, StringSplitOptions.RemoveEmptyEntries).ToList();

        string command = Console.ReadLine();
        while (command != "course start")
        {
            var commandTokens = command.Split(':').ToList();

            string courseName = commandTokens[1];
            bool alreadyExists = course.Contains(courseName);

            switch (commandTokens[0])
            {
                case "Add":
                    if (!alreadyExists)
                    {
                        course.Add(courseName);
                    }
                    break;

                case "Insert":
                    if (!alreadyExists)
                    {
                        int index = int.Parse(commandTokens[2]);
                        if (index >= 0 && index < course.Count())
                        {
                            course.Insert(index, courseName);
                        }
                    }
                    break;

                case "Remove":
                    if (alreadyExists)
                    {
                        foreach (var courseTitle in course)
                        {
                            var courseTokens = courseTitle.Split('-').ToList();
                            if (courseTokens[0] == courseName)
                            {
                                course.Remove(courseTitle);
                                break;
                            }
                        }
                    }
                    break;

                case "Swap":
                    string secondCourse = commandTokens[2];

                    var firstCourseName = string.Empty;
                    int indexOfFirstCourse = -1;

                    var secondCourseName = string.Empty;
                    int indexOfSecCourse = -1;
                    foreach (var courseTitle in course)
                    {
                        var courseTokens = courseTitle.Split('-').ToList();
                        var currentCourse = courseTokens[0];

                        if (currentCourse == courseName)
                        {
                            firstCourseName = courseTitle;
                            indexOfFirstCourse = course.IndexOf(courseTitle);
                        }
                        else if (currentCourse == secondCourse)
                        {
                            secondCourseName = currentCourse;
                            indexOfSecCourse = course.IndexOf(courseTitle);
                        }

                    }
                    bool bothExists = firstCourseName != string.Empty && secondCourseName != string.Empty;
                    if (bothExists == true)
                    {
                        string temporary = course[indexOfFirstCourse];

                        course[indexOfFirstCourse] = course[indexOfSecCourse];
                        course[indexOfSecCourse] = temporary;
                    }
                    break;

                case "Exercise":

                    bool isNotNewCourse = false;
                    foreach (var courseTitle in course)
                    {
                        var courseTokens = courseTitle.Split('-').ToList();
                        var currentCourse = courseTokens[0];

                        if (currentCourse == courseName)
                        {

                            bool alreadyHasExercise = courseTokens.Count() > 1;
                            if (!alreadyHasExercise)
                            {
                                int indexOfCourse = course.IndexOf(courseTitle);
                                course[indexOfCourse] += "-Exercise";
                            }
                            isNotNewCourse = true;
                        }
                    }

                    if (isNotNewCourse == false)
                    {
                        course.Add($"{courseName}-Exercise");
                    }
                    break;
            }

            command = Console.ReadLine();
        }


        for (int index = 0; index < course.Count(); index++)
        {
            var item = course[index];
            var itemTokens = item.Split('-');
            if (itemTokens.Count() > 1)
            {
                course[index] = itemTokens[0];
                course.Insert(index + 1, $"{itemTokens[0]}-Exercise");
                index += 2;
            }

        }

        foreach (var lesson in course)
        {
            int index = course.IndexOf(lesson) + 1;
            Console.WriteLine($"{index}.{lesson}");
        }
    }
}