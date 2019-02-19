using System;

namespace Q01_Blank_Reciept
{
    class Q01
    {
        static void Main(string[] args)
        {
            Header();
            Body();
            Footer();
            
        }

        static void Header()
        {
            Console.WriteLine(@"CASH RECEIPT
------------------------------");
        }

        static void Body()
        {
            Console.WriteLine(@"Charged to____________________
Received by___________________");
        }

        static void Footer()
        {
            Console.WriteLine(@"------------------------------
© SoftUni");
        }
    }
}
