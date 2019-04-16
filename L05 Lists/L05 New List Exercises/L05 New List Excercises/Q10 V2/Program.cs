using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        //not my code

        string seperator = ", ";
        var lessons = Console.ReadLine().Split(new string[] { seperator }, StringSplitOptions.RemoveEmptyEntries).ToList(); // read the input 

        string command = string.Empty;

        string action = string.Empty; // add, remove, insert , swap , exercise 
        string element = string.Empty; // Covers only Add / Remove / Exercise



        string lesson = string.Empty; // covers only insert 
        int index = 0; // covers only insert 
        string element1 = string.Empty;// Covers only insert and swap

        string firstLesson = string.Empty; // covers only swap !
        string secondLesson = string.Empty; // covers only swap ! 


        while (true)
        {
            command = Console.ReadLine();// read commands 

            if (command == "course start")
            {
                break;
            }

            List<string> incomingDetails = command.Split(':').ToList(); // get a list of the input commands   separated by : 

            for (int i = 0; i < incomingDetails.Count; i++)
            {
                action = incomingDetails[0]; // what we need to do 
                element = incomingDetails[1]; // which course to look for. Covers only Add / Remove / Excercise that have 2 elements only 


                if (action == "Insert")
                {
                    index = int.Parse(incomingDetails[2]);
                    lesson = element;  // this is the lesson to insert 
                                       //index = elementInsert; // this is the index where to insert the lesson 

                    break;
                }

                else if (action == "Swap")
                {
                    string elementInsert = incomingDetails[2]; // to cover swap  

                    firstLesson = incomingDetails[1];
                    secondLesson = incomingDetails[2];

                    break;
                }
            }

            for (int k = 0; k < lessons.Count; k++)
            {
                if (action == "Add") // 
                {
                    if (!lessons.Contains(element)) //if it does not exist
                    {
                        lessons.Add(element);
                    }


                }

                else if (action == "Remove") //  if it exists.

                //Each time you Remove a lesson, you should do the same with the Exercises, if there are any, which follow the lessons. 
                {

                    string excercise = element + '-' + "Exercise";

                    if (lessons.Contains(element))
                    {
                        lessons.Remove(element);

                    }

                    if (lessons.Contains(excercise))
                    {
                        lessons.Remove(excercise);
                    }


                }


                else if (action == "Exercise")
                {
                    string excercise = element + '-' + "Exercise";



                    if (!lessons.Contains(element))
                    {

                        if (!lessons.Contains(excercise)) // If the lesson doesn`t exist, add the lesson in the end of the course schedule, followed by the Exercise. 
                        {
                            lessons.Add(element);
                            lessons.Add(excercise);
                            break;
                        }


                        break;
                    }

                    else if (lessons.Contains(element) && !lessons.Contains(excercise)) // if the lesson exists and there is no exercise already, add the excercise to the right place  
                    {
                        int indexx = lessons.IndexOf(element);
                        lessons.Insert(indexx + 1, excercise);

                        break;

                    }


                }

                else if (action == "Insert")
                {
                    if (!lessons.Contains(lesson)) // insert the lesson to the given index, if it does not exist
                    {
                        lessons.Insert(index, lesson);
                        break;
                    }


                    break;
                }


                else if (action == "Swap") // change the place of the two lessons, if they exist!!
                {



                    if (lessons.Contains(firstLesson) && lessons.Contains(secondLesson))
                    {
                        string excercise = firstLesson + '-' + "Exercise";


                        int index1 = lessons.IndexOf(firstLesson); // know where is the 1st lesson
                        int index2 = lessons.IndexOf(secondLesson); // know where is the  2nd lesson

                        string temp = firstLesson;

                        lessons.RemoveAt(index1); // remove the 1st part of the swap / lesson

                        lessons.Insert(index1, secondLesson);



                        if (lessons.Contains(excercise))
                        {
                            lessons.Remove(excercise);
                            lessons.Insert(index1 + 1, excercise);
                        }

                        excercise = string.Empty;
                        excercise = secondLesson + '-' + "Exercise"; // excercise related to the second lesson


                        lessons.RemoveAt(index2);// remove the second lesson  part from its old index


                        lessons.Insert(index2, temp); //insert the second lesson to the new  index



                        if (lessons.Contains(excercise))
                        {

                            lessons.Remove(excercise);

                            lessons.Insert(index1 + 1, excercise); // insert the excercise for the second lesson


                        }

                    }


                    break;
                }

            }


        }




        for (int p = 0; p < lessons.Count; p++)
        {
            Console.WriteLine($"{p + 1}.{lessons[p]}");
        }
    }
}