using System;
using System.Text;
public class Program
{
    public static void Main()
    {
        //Write a method that receives a single integer n and prints nxn matrix with that number.

        int matrixSize = int.Parse(Console.ReadLine());

        PrintMatrix(matrixSize);
    }

    static void PrintMatrix(int matrixSize)
    {
        var sb = new StringBuilder();

        for (int i = 0; i < matrixSize; i++)
        {
            sb.Append(matrixSize);
            sb.Append(' '); // you will have an extra collumn of ' ' on the i == matrixSize - 1
        }

        string line = sb.ToString();

        for (int indexOfLine = 0; indexOfLine < matrixSize; indexOfLine++)
        {
            Console.WriteLine(line);
        }
    }
}