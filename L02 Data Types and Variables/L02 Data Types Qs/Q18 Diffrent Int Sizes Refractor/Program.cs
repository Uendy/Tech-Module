using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Q18_Diffrent_Int_Sizes_Refractor
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger inputNumber = BigInteger.Parse(Console.ReadLine());


            bool negativeCheck = inputNumber < 0; // if negative => true

            bool longRangeCheck = inputNumber >= long.MinValue && inputNumber <= long.MaxValue;
            if (longRangeCheck == true)
            {
                Console.WriteLine($"{inputNumber} can fit in:");

                bool uintRangeCheck = inputNumber <= uint.MaxValue;
                if (uintRangeCheck == true)
                {
                    bool intRangeCheck = inputNumber >= int.MinValue && inputNumber <= int.MaxValue;
                    if (intRangeCheck == true)
                    {
                        bool ushortRangeCheck = inputNumber <= ushort.MaxValue;
                        if (ushortRangeCheck == true)
                        {
                            bool shortRangeCheck = inputNumber >= short.MinValue && inputNumber <= short.MaxValue;
                            if (shortRangeCheck == true)
                            {
                                bool byteRangeCheck = inputNumber <= byte.MaxValue;
                                if (byteRangeCheck == true)
                                {
                                    bool sbyteRangeCheck = inputNumber >= sbyte.MinValue && inputNumber <= sbyte.MaxValue;
                                    if (sbyteRangeCheck == true)
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
