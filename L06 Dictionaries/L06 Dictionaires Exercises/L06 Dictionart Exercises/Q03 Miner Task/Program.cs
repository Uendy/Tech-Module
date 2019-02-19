using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q03_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            var mineralCatalogue = new Dictionary<string, int>();

            for (int index = 0; index < 100; index+=2)
            {
                    string mineral = Console.ReadLine();

                    if (mineral == "stop")
                    {
                    StopProtocol(mineralCatalogue);
                    }

                bool alreadyContainsKey = mineralCatalogue.ContainsKey(mineral);
                if (alreadyContainsKey == false)
                {
                    mineralCatalogue[mineral] = 0;
                }

                    int quantityOfMineral = int.Parse(Console.ReadLine());
                    mineralCatalogue[mineral] += quantityOfMineral;
            }
        }

        static void StopProtocol(Dictionary<string, int> mineralCatalogue)
        {
            foreach (var item in mineralCatalogue)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
            Environment.Exit(0);
        }
    }
}
