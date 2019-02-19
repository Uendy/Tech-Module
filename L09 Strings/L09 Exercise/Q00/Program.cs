using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Q00
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var sb = new StringBuilder();

            for (int i = 0; i <= 1998; i++)
            {
                sb.Append(i.ToString());
            }

            var output = sb.ToString();
            Console.WriteLine(output);

            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);

        }
    }
}
