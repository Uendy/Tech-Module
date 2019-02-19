using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q01
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            //input.Sort(); this was my mistake 2 2 7 7 and 7 7 2 2 would both give 2 2 output and I was confused why

            int topSequenceCounter = 1;
            int currentSequenceCounter = 1;
            int sequenceStarter = input[0];

            for (int index = 0; index < input.Count-1; index++)
            {
                bool sequnce = input[index] == input[index + 1];

                if (sequnce == true)
                {
                    if (index == input.Count - 2)
                    {
                        currentSequenceCounter++;

                        if (currentSequenceCounter > topSequenceCounter)
                        {
                            sequenceStarter = input[index];

                            string earlyOutput = "";
                            for (int write = 1; write <= currentSequenceCounter; write++)
                            {
                                earlyOutput += sequenceStarter + " ";
                            }

                            Console.WriteLine(earlyOutput.TrimEnd());
                            return;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    currentSequenceCounter++;

                }
                else
                {
                    if (currentSequenceCounter <= topSequenceCounter)
                    {
                        currentSequenceCounter = 1;
                    }
                    else
                    {
                        topSequenceCounter = currentSequenceCounter;
                        sequenceStarter = input[index];
                        currentSequenceCounter = 1;
                    }
                }
            }
            string output = "";
            for (int i = 1; i <= topSequenceCounter; i++)
            {
                output += sequenceStarter + " ";
            }
            Console.WriteLine(output.TrimEnd());
        }
    }
}