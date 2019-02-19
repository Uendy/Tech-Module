using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Q18_Different_Integer_SIze
{
    class Program
    {
        static void Main(string[] args)
        {
            //sbyte < byte < short < ushort < int < uint < long .maxValue
            

            BigInteger inputNumber = BigInteger.Parse(Console.ReadLine());
            
            
            bool negativeCheck = inputNumber < 0; // if negative => true

            if (inputNumber >= long.MinValue && inputNumber <= long.MaxValue)
            {
                Console.WriteLine($"{inputNumber} can fit in:");
                if (inputNumber <= uint.MaxValue)
                {
                    if (inputNumber >= int.MinValue && inputNumber <= int.MaxValue)
                    {
                        if (inputNumber <= ushort.MaxValue)
                        {
                            if (inputNumber >= short.MinValue && inputNumber <= short.MaxValue)
                            {
                                if (inputNumber <= byte.MaxValue)
                                {
                                    if (inputNumber >= sbyte.MinValue && inputNumber <= sbyte.MaxValue)
                                    {
                                        Console.WriteLine("* sbyte");
                                    }
                                    if (negativeCheck == false)
                                    {
                                        Console.WriteLine("* byte");
                                    }
                                }
                                Console.WriteLine("* short");
                            }
                            if (negativeCheck == false)
                            {
                                Console.WriteLine("* ushort");
                            }
                        }
                        Console.WriteLine("* int");
                    }
                    if (negativeCheck == false)
                    {
                        Console.WriteLine("* uint");
                    }
                }
                Console.WriteLine("* long");
            }
            else
            {
                Console.WriteLine($"{inputNumber} can't fit in any type");
            }
        }
    }
}
