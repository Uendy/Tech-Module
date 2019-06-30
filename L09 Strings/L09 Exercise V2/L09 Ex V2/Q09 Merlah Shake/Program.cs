using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

    }
}