using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        #region
        //You are given number of files with their full file paths and file sizes. 
        //You need to print all file names with a given extension that are present in a given root directory sorted by their file size in descending order. 
        //If two files have same size, order them by alphabetical order.

        //If a file name(file name +extension) appears more than once in a given root, save only its latest value.
        //If a file name appears in more than one root, they are treated as different files.
        //If there aren't any files that correspond to the query, print "No".

        //Input / Constrains
        //•	On the first line of input you will get N the number of files to be read from the console.
        //•	On the next N lines, you receive the actual files in the format “root\folder\filename.extension; filesize”.
        //•	There may be more than one folder, e.g.folders can be deeply nested.
        //•	On the last line you receive a query string in format “{ extension} in { root}”.
        //You need to print all files with the given extension that are in present in the given root.

        //Output
        //•	You need to print all files sorted by their size in descending order.
        //•	If two files have the same size, order them by alphabetical order.
        //•	Files should be printed in the given format "filename.extension - filesize KB".
        //•	If there aren't any movies that correspond to the query, print "No".
        #endregion

        //var dict = new Dict<string, Dict<string, Dict<string, long>>>
        //outer dict : key == root <string>, value == extension <string>                             OuterDict <root, extentsion>
        //medium dict : key == extension <string> (also outerDict value), value = file <string>      MediumDict <extension, file>
        //inner dict : key (also mediumDict value) == file <string>, value == filesize <long> in KB  InnerDict <file, fileSize>

        var dict = new Dictionary<string, Dictionary<string, Dictionary<string, long>>>();

        int numberOfInputs = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfInputs; i++)
        {
            string input = Console.ReadLine();

            var fileSizeSplit = input.Split(';').ToArray();
            long fileSize = long.Parse(fileSizeSplit[1]);

            var tokensSplit = fileSizeSplit[0].Split('\\').ToArray();
            string root = tokensSplit[0];

            var fileAndExtension = tokensSplit.Last();
            string extension = fileAndExtension.Split('.').ToArray().Last();


            bool newRoot = !dict.ContainsKey(root);
            if (newRoot)
            {
                dict[root] = new Dictionary<string, Dictionary<string, long>>();
            }

            var outerDict = dict[root]; 

            bool newExtension = !outerDict.ContainsKey(extension);
            if (newExtension)
            {
                outerDict[extension] = new Dictionary<string, long>();
            }

            var middleDIct = outerDict[extension];

            // if new or old, you get the newest version of the fileSize of the file
            middleDIct[fileAndExtension] = fileSize;
        }
    }
}