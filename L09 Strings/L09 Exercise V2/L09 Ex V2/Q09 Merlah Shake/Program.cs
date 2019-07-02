using System;
public class Program
{
    public static void Main()
    {
        //You are given a string of random characters, and a pattern of random characters. 
        //You need to “shake off” (remove) all of the border occurrences of that pattern, in other words:
        // the very first match and the very last match of the pattern you find in the string.
        //When you successfully shake off a match,
        //you remove from the pattern the character which corresponds to the index equal to the pattern’s length / 2.
        //Then you continue to shake off the border occurrences of the new pattern until,
        //the pattern becomes empty or until there is less than the - needed for shake, matches in the remaining string.
        //In case you have found at least two matches, and you have successfully shaken them off, 
        //you print “Shaked it.” on the console.Otherwise you print “No shake.”, 
        //the remains of the main string, and you end the program.See the examples for more info.

        var input = Console.ReadLine();
        var substring = Console.ReadLine();

        while (true)
        {
            var firstOccurance = input.IndexOf(substring);
            var lastOccurance = input.LastIndexOf(substring);

            bool iscontained = firstOccurance != -1 && lastOccurance != -1 && firstOccurance != lastOccurance && substring.Length != 0;
            if (iscontained == true)
            {
                input = input.Remove(lastOccurance, substring.Length);
                input = input.Remove(firstOccurance, substring.Length);

                var removedIndex = substring.Length / 2;
                substring = substring.Remove(removedIndex, 1);
                Console.WriteLine("Shaked it.");
            }
            else
            {
                EndingRemarks(input);
            }
        }
    }

    static void EndingRemarks(string text)
    {
        Console.WriteLine("No shake.");
        Console.WriteLine(text);
        Environment.Exit(0);
    }
}