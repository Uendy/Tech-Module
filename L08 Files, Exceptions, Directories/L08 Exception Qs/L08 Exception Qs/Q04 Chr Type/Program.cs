using System.Linq;
using System.IO;
public class Program
{
    public static void Main()
    {
        //Write a program that reads a list of words from the file (input.txt from the Resources - Exercises)  
        //finds the count of vowels, consonants and punctuation marks. Assume that:
        //•	a, e, i, o, u are vowels, only lower case
        //•	All others are consonants
        //•	Punctuation marks are(!,.?)
        //•	Do not count whitespace.
        //Write the results to another file – output.txt.

        var inputName = "inputText.txt";

        var inputFile = File.ReadAllLines(inputName);

        int vowelCount = 0;
        int consonantCount = 0;
        int punctuationCount = 0;

        foreach (var line in inputFile)
        {
            var lineAsArray = line.Replace(" ", "").ToCharArray();
            foreach (var charecter in lineAsArray)
            {
                var vowelArray = new char[] { 'a', 'e', 'i', 'o', 'u' }; //only lowerCase
                var punctuationArray = new char[] { '!', ',', ',', '?' };

                bool isVowel = vowelArray.Contains(charecter);
                if (isVowel)
                {
                    vowelCount++;
                }
                else
                {
                    bool isPunctuation = punctuationArray.Contains(charecter);
                    if (isPunctuation)
                    {
                        punctuationCount++;
                    }
                    else // is a consonant
                    {
                        consonantCount++;
                    }
                }
            }

        }

        var outPut = new string[3];
        outPut[0] = $"Vowels: {vowelCount}";
        outPut[1] = $"Consonants: {consonantCount}";
        outPut[2] = $"Punctuation: {punctuationCount}";

        File.WriteAllLines("output.txt", outPut);
    }
}