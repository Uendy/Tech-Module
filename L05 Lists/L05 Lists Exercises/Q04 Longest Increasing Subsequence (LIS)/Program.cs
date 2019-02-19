using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q04_Longest_Increasing_Subsequence__LIS_
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var inputAsInt = input
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            var inputAsString = input.Split(' ').ToList();

            var scoreKeeper = new List<string>();

            for (int topOrBottom = 0; topOrBottom < 2; topOrBottom++)
            {
                // 0 == top and 1 == bottom 
                for (int numberOfRestrictors = 0; numberOfRestrictors < inputAsInt.Count; numberOfRestrictors++)
                {
                    // this does the *index part outside
                    // This will also choose how many *Restrictors I will use*

                    for (int index = 0; index < inputAsInt.Count; index++)
                    {
                        // this drives the numbers by index
                        if (numberOfRestrictors == 0)
                        {
                            scoreKeeper.Insert(index, inputAsString[index]);
                            int highest = inputAsInt[index];

                            for (int secondIndex = index + 1; secondIndex < inputAsInt.Count; secondIndex++)
                            {
                                // this spins the 2nd index from input
                                bool sequence = highest < inputAsInt[secondIndex];
                                if (sequence == true)
                                {
                                    highest = inputAsInt[secondIndex];
                                    scoreKeeper[index] += " " + inputAsString[secondIndex];
                                }

                            }
                        }
                        else // the problem is here in that I do not know how to skip over multiple index's rhythmically
                        {

                            int currentIndex = numberOfRestrictors * (inputAsInt.Count) + index; 
                            scoreKeeper.Insert(currentIndex, inputAsString[index]);

                            if (topOrBottom == 0)
                            {
                                var upperLimiters = input // top ones
                                    .Split(' ')
                                    .Select(int.Parse)
                                    .ToList();
                               // upperLimiters.Sort();
                                upperLimiters.Reverse();

                                var restrictors = new List<int>();
                                for (int indexOfRestrictors = 0; indexOfRestrictors < numberOfRestrictors; indexOfRestrictors++)
                                {
                                    restrictors.Insert(indexOfRestrictors, upperLimiters[indexOfRestrictors]);
                                    //my problem is that if in my input I have 2 of the same int, 1 restrictor would continue over both not just one
                                }

                                int highest = inputAsInt[index];
                                for (int secondIndex = index + 1; secondIndex < inputAsInt.Count; secondIndex++)
                                {
                                    bool maybeIMissedThis = false;
                                    for (int highestRestrictors = 0; highestRestrictors < numberOfRestrictors; highestRestrictors++)
                                    {
                                        if (inputAsInt[secondIndex] == upperLimiters[highestRestrictors])
                                        {
                                            maybeIMissedThis = true;
                                        }
                                    }
                                    if (maybeIMissedThis == true)
                                    {
                                        continue;
                                    }

                                    bool sequence = highest < inputAsInt[secondIndex];
                                    if (sequence == true)
                                    {
                                        highest = inputAsInt[secondIndex];
                                        scoreKeeper[currentIndex] += " " + inputAsString[secondIndex];
                                    }
                                }
                            }
                            else // bottom
                            {
                                var bottomLimiters = input
                                    .Split(' ')
                                    .Select(int.Parse)
                                    .ToList();
                                //bottomLimiters.Sort();

                                var restrictors = new List<int>();

                                for (int indexOfRestrictor = 0; indexOfRestrictor < numberOfRestrictors; indexOfRestrictor++)
                                {
                                    restrictors.Insert(indexOfRestrictor,bottomLimiters[indexOfRestrictor]);
                                }

                                int highest = inputAsInt[index];
                                for (int secondIndex = index + 1; secondIndex < inputAsInt.Count; secondIndex++)
                                {
                                    bool maybeIMissedThis = false;
                                    for (int highestRestrictors = 0; highestRestrictors < numberOfRestrictors; highestRestrictors++)
                                    {
                                        if (inputAsInt[secondIndex] == bottomLimiters[highestRestrictors])
                                        {
                                            maybeIMissedThis = true;
                                        }
                                    }
                                    if (maybeIMissedThis == false)
                                    {
                                        continue;
                                    }

                                    bool sequence = highest < inputAsInt[secondIndex];
                                    if (sequence == true)
                                    {
                                        highest = inputAsInt[secondIndex];
                                        scoreKeeper[currentIndex] += " " + inputAsString[secondIndex];
                                    }
                                }
                            }
                        }

                    }

                }
            }
            int LongestIndex = 0;
            // ill need another for cycle for the * outer and have an overall longest Index counter running though both

            for (int index = 1; index < scoreKeeper.Count; index++)
            {

                bool bigger = scoreKeeper[index - 1].Length > scoreKeeper[LongestIndex].Length;
                if (bigger == true)
                {
                    LongestIndex = index - 1;
                }
                else
                {
                    continue;
                }
            }

            Console.WriteLine(scoreKeeper[LongestIndex]);
        }
    }
}
