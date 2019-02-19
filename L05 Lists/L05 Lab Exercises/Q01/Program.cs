using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q01
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string values = Console.ReadLine();
            List<string> items = values.Split(' ').ToList();
            List<int> numbers = new List<int>();

            for (int i = 0; i < items.Count; i++)
            {
                numbers.Add(int.Parse(items[i]));
            }

            numbers.RemoveAll(x => x < 0);

            numbers.Reverse();

            bool isEmpty = !numbers.Any(); // how to check if a List is empty
            if (isEmpty == true)
            {
                Console.WriteLine("Empty");
            }
            else
            {
                Console.WriteLine(String.Join(" ", numbers));
            }
        }
    }
}
