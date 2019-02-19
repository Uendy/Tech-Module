using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q02_Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();


            bool done = false;
            while (!done)
            {
                var action = Console.ReadLine()
                .Split(' ')
                .ToList();

                switch (action[0])
                {
                    case "Odd":
                        input.RemoveAll(x => x % 2 == 0);
                        done = true;
                        break;

                    case "Even":
                        input.RemoveAll(x => x % 2 != 0);
                        done = true;
                        break;

                    case "Delete":
                        int deleteThisNumber = Int32.Parse(action[1]);
                        input.RemoveAll(x => x == deleteThisNumber);
                        break;

                    case "Insert":
                        int element = Int32.Parse(action[1]);
                        int index = Int32.Parse(action[2]);
                        input.Insert(index, element);
                        break;
                }
            }
            Console.WriteLine(String.Join(" ", input));
        }
    }
}
