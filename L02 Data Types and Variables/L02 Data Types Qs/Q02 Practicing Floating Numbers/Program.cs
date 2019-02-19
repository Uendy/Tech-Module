using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q02_Practicing_Floating_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //3.141592653589793238
            //1.60217657
            //7.8 184 261 974 584 555 216 535 342 341
            decimal twentyDigitNumber = decimal.Parse(Console.ReadLine());
            double tenDigitNumber = double.Parse(Console.ReadLine());
            decimal thirtyDigitNumber = decimal.Parse(Console.ReadLine());

            Console.WriteLine(twentyDigitNumber);
            Console.WriteLine(tenDigitNumber);
            Console.WriteLine(thirtyDigitNumber);
        }
    }
}
