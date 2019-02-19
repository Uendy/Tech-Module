using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q04_Part_3
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

            var inputAsString = input
                .Split(' ')
                .ToList();

            var scoreKeeper = new List<string>();

            for (int polarityOfRestrictors = 0; polarityOfRestrictors < 2; polarityOfRestrictors++)
            {
                // 0 == lowest (.Sort()) && 1 == highest (.Sort.Reverse())
                for (int numberOfRestrictors = 0; numberOfRestrictors < inputAsInt.Count; numberOfRestrictors++)
                {
                    // this does the *index part outside ????
                    // This will also choose how many *Restrictors I will use* 

                    for (int index = 0; index < inputAsInt.Count; index++)
                    {
                        // this loop drives numbers left to right via index

                        int currentIndex = numberOfRestrictors * (inputAsInt.Count) + index;
                        scoreKeeper.Insert(currentIndex, inputAsString[index]);
                        int highestValueSoFar = inputAsInt[index];

                        var restricotrs = new List<int>();
                        if (polarityOfRestrictors == 0) //lower end restrictors
                        {
                            var lowEndRestrictors = new List<int>(inputAsInt);
                            lowEndRestrictors.Sort();

                            for (int restrictor = 0; restrictor < numberOfRestrictors; restrictor++)
                            {
                                restricotrs.Insert(restrictor, lowEndRestrictors[restrictor]);
                            }
                        }
                        else // top end restrictos
                        {
                            var highEndRestrictors = new List<int>(inputAsInt);
                            highEndRestrictors.Sort();
                            highEndRestrictors.Reverse();

                            for (int restrictor = 0; restrictor < numberOfRestrictors; restrictor++)
                            {
                                restricotrs.Insert(restrictor, highEndRestrictors[restrictor]);
                            }
                        }

                        for (int rightOfIndex = index + 1; rightOfIndex < inputAsInt.Count; rightOfIndex++)
                        {
                            // this is the number to the right of Index we will check to see if it is bigger than Index
                            bool sequenceCheck = highestValueSoFar < inputAsInt[rightOfIndex];

                            int timesSkipper = 0; // to prevent jumping over the same number twice with 1 restrictor
                            bool skipRightOfIndex = false;
                            for (int indexOfRestrictor = 0; indexOfRestrictor < numberOfRestrictors; indexOfRestrictor++)
                            {
                                bool skip = inputAsInt[rightOfIndex] == restricotrs[indexOfRestrictor];
                                if (skip == true)
                                {
                                    skipRightOfIndex = true;
                                    timesSkipper++;
                                }
                            }
                            //var sameNumberMultipleTimes = inputAsInt.FindAll(x => x == inputAsInt[rightOfIndex]);
                            //if (sameNumberMultipleTimes.Count > 1)
                            //{
                            //    if (timesSkipper == 1)
                            //    {
                            //        skipRightOfIndex = false;
                            //    }
                            //}

                            if (skipRightOfIndex == true)
                            {
                                continue;
                            }

                            if (sequenceCheck == true)
                            {
                                scoreKeeper[currentIndex] += " " + inputAsString[rightOfIndex];
                                highestValueSoFar = inputAsInt[rightOfIndex];
                            }
                        }
                    }
                }
            }
            scoreKeeper.Remove(" "); // don't know if that did the trick I gotta check
            int longestLength = scoreKeeper[0].Length;
            // .Remove(' ')
            // what the hell is wrong with it?
            for (int index = 1; index < scoreKeeper.Count; index++)
            {
                bool longerLength = scoreKeeper[index].Length > scoreKeeper[longestLength].Length;
                {
                    if (longerLength == true)
                    {
                        longestLength = scoreKeeper[index].Length;
                    }
                }
            }

            for (int index = 0; index < scoreKeeper.Count; index++)
            {
                bool notLongestLength = scoreKeeper[index].Length < longestLength;
                if (notLongestLength == true)
                {
                    scoreKeeper[index] = "abc"; 
                }
            }

            for (int index = 0; index < scoreKeeper.Count; index++)
            {
                if (scoreKeeper[index] == "abc")
                {
                    scoreKeeper.RemoveAt(index); // THIS IS NOT RIGHT IT COULD SKIP OVER MANY abcs
                }
            }

            var finalList = new List<int>();
            int shortest = int.MaxValue;
            for (int indexOfLeftoverScoreKeeper = 0; indexOfLeftoverScoreKeeper < scoreKeeper.Count; indexOfLeftoverScoreKeeper++)
            {
                var currentStringCheck = scoreKeeper[indexOfLeftoverScoreKeeper]; // see if you need .Remove(' ')

                int indexTotal = 0;    
                for (int scoreKeeperInnerIndex = 0; scoreKeeperInnerIndex < currentStringCheck.Length; scoreKeeperInnerIndex++)
                {
                    var checkNonInput = currentStringCheck[scoreKeeperInnerIndex].ToString(); // WOW .ToString() saved me

                    for (int indexOfInput = 0; indexOfInput < inputAsString.Count; indexOfInput++)
                    {
                       var checkInput = inputAsString[indexOfInput];

                        bool sameNumberAsString = checkNonInput == checkInput;
                        if (sameNumberAsString == true)
                        {
                            indexTotal += indexOfInput;
                        }
                    }
                    finalList.Insert(indexOfLeftoverScoreKeeper, shortest);
                    if (indexTotal < shortest)
                    {
                        shortest = indexTotal;
                        indexTotal = 0;
                    }
                }

                //for (int index = 0; index < finalList.Count; index++)
                //{
                //    bool theRightIndex = finalList[index] == shortest;
                //    if (theRightIndex == true)
                //    {
                //        Console.WriteLine(scoreKeeper[index]);
                //    }
                //}
            }
            for (int index = 0; index < finalList.Count; index++)
            {
                bool theRightIndex = finalList[index] == shortest;
                if (theRightIndex == true)
                {
                    Console.WriteLine(scoreKeeper[index]);
                }
            }
        }
    }
}
