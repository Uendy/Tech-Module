using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Q05_Folder_Size
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentFile = Directory.GetFiles("TestFolder");

            double sum = 0.0;

            foreach (var file in currentFile)
            {
                var fileInfo = new FileInfo(file);
                sum += fileInfo.Length;
            }

            Console.WriteLine(sum / 1024.0 / 1024.0);

        }
    }
}
