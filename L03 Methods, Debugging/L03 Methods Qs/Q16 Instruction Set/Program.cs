using System;
using System.Numerics;

class InstructionSet_broken
{
    static void Main()
    {
        string opCode = Console.ReadLine().ToUpper();
        

        while (opCode != "END")
        {
            string[] codeArgs = opCode.Split(' ');

            BigInteger result = 0;
            switch (codeArgs[0])
            {
                case "INC":
                    {
                        int operandOne = int.Parse(codeArgs[1]);
                        result = ++operandOne;
                        break;
                    }
                case "DEC":
                    {
                        int operandOne = int.Parse(codeArgs[1]);
                        result = --operandOne;
                        break;
                    }
                case "ADD":
                    {
                        int operandOne = int.Parse(codeArgs[1]);
                        int operandTwo = int.Parse(codeArgs[2]);
                        result = (long)operandOne + (long)operandTwo;
                        break;
                    }
                case "MLA":
                    {
                        int operandOne = int.Parse(codeArgs[1]);
                        int operandTwo = int.Parse(codeArgs[2]);
                        result = ((long)operandOne * (long)operandTwo);
                        break;
                    }
                default:
                        break;
            }
            opCode = Console.ReadLine();
            Console.WriteLine(result);
        }
       
    }
}