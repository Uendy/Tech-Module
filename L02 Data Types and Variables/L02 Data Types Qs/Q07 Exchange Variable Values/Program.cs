﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q07_Exchange_Variable_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = 10;

            int olda = a;
            int oldb = b;

            a = b; //a = 10
            b = olda; // b = 5

            Console.WriteLine("Before:");
            Console.WriteLine($"a = {olda}");
            Console.WriteLine($"b = {oldb}");
            Console.WriteLine("After:");
            Console.WriteLine($"a = {a}");
            Console.WriteLine($"b = {b}");
        }
    }
}
