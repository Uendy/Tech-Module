using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q14_Integer_to_Hex_and_Binary
{
    class Program
    {
        static void Main(string[] args)
        {
            //SuperUseful Question!

            int givenNumber = int.Parse(Console.ReadLine());

            string hexadecimalNumber = Convert.ToString(givenNumber, 16);
            string capitalHexadecimalNumber = hexadecimalNumber.ToUpper();
            string binaryNumber = Convert.ToString(givenNumber, 2);

            Console.WriteLine(capitalHexadecimalNumber);
            Console.WriteLine(binaryNumber);
        }
    }
}
