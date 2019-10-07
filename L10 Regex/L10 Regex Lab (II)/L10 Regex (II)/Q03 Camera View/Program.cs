using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
public class Program
{
    public static void Main()
    {
        //You are an amateur photographer and you want to calculate what will be seen in your pictures.

        //On the first line, you will receive an array of integers with exactly two elements:
        //First element – m will be the elements, which you have to skip.The second element – n will be the elements, which you have to take.
        //On the next line, you will receive a string, in which every camera will be marked with "|<".
        //Skip the next m elements immediately after the camera and take the next n elements.

        //If you encounter new camera in the view  stop the current camera and start new view with the newly found.

        var skipAndTake = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int skip = skipAndTake[0] + 2; // since each match will have "|<" before it
        int take = skipAndTake[1];

        string input = Console.ReadLine();

        string pattern = @"\|<\w+";
        var regex = new Regex(pattern);

        var matches = regex.Matches(input);
        var outPuts = new List<string>();
        foreach (Match match in matches)
        {
            string substring = match.Value;
            var coreSubstring = substring.Skip(skip).ToList();
            string currentOutPut = string.Join("", coreSubstring);
            outPuts.Add(currentOutPut);
        }

        string outPut = string.Join(", ", outPuts);
        Console.WriteLine(outPut);
    }
}