using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q06_Triple_Latin_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            int limit = int.Parse(Console.ReadLine());
            char maxlim = (char)(limit + 96);

            for (char letterOne = 'a'; letterOne <= maxlim; letterOne++)
            {
                for (char letterTwo = 'a'; letterTwo <= maxlim; letterTwo++)
                {
                    for (char letterThree = 'a'; letterThree <= maxlim; letterThree++)
                    {
                        Console.WriteLine($"{letterOne}{letterTwo}{letterThree}");
                    }

                }
            }
        }
    }
}
