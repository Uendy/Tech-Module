using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q04_Triple_Sum
{
    class Program
    {
        static void Main(string[] args)
        {

            // 60/100 Check Video Later

            int[] arrayAsInts = Console.ReadLine().Split(new char[] { ',',' '},StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            bool justOneNo = true;

            for (int leftNumber = 0; leftNumber <= arrayAsInts.Length-1; leftNumber++)
            {

                for (int rightNumber = 0; rightNumber <= arrayAsInts.Length-1; rightNumber++)
                {
                    bool leftBiggerOrEqual = leftNumber >= rightNumber;
                    if (leftBiggerOrEqual)
                    { continue; }

                    for (int answeNumber = 0; answeNumber <= arrayAsInts.Length-1; answeNumber++)
                    {
                        //bool answerBiggerThanRight = rightNumber <= answeNumber;
                        //if (answerBiggerThanRight)
                        //{ continue; }


                        bool tripleSum = arrayAsInts[leftNumber] + arrayAsInts[rightNumber] == arrayAsInts[answeNumber];

                        if (tripleSum == true)
                        {
                            Console.WriteLine($"{arrayAsInts[leftNumber]} + {arrayAsInts[rightNumber]} == {arrayAsInts[answeNumber]}");
                            justOneNo = false;
                        }

                    }
                }
            }

            if (justOneNo == true)
            {
                Console.WriteLine("No");
            }
        }
    }
}
