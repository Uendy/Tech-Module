using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        #region
        //You will receive several input lines in one of the following formats:
        //•	{ dataSet}
        //•	{ dataKey} -> { dataSize} | { dataSet}

        //The dataSet and dataKey are both strings.The dataSize is an integer. The dataSets hold dataKeys and their dataSizes.

        //If you receive only a dataSet you should add it. If you receive a dataKey and a dataSize, you should add them to the given dataSet.
        //And here’s where the fun begins.If you receive a dataKey and a dataSize, 
        //but the given dataSet does NOT exist, you should STORE those keys and values in a cache. 
        //When the corresponding dataSet is added, you should check if the cache holds any keys and values referenced to it, 
        //and you should add them to the dataSet.

        //You should end your program when you receive the command “thetinggoesskrra”.  
        //At that point you should extract the dataSet from the data with the HIGHEST dataSize(SUM of all its dataSizes), 
        //and you should print it.

        //NOTE: Elements in the cache, should be CONSIDERED NON - EXISTANT.You should NOT count them in the final output.
        //In case there are NO dataSets in the data, you should NOT do anything.

        //one overall dict[dataSet][dateKey] = datasize 
        //one dict cache [dateSet][dataKey] = datasize
        #endregion

        //both dicts have outerKey = <string> dataSet, innerKey/outerValue = <string> dataKey, innerValue = <long>dataSize
        var overAll = new Dictionary<string, Dictionary<string, long>>();
        var cache = new Dictionary<string, Dictionary<string, long>>();

        string currentInput = Console.ReadLine();
        while (currentInput != "thetinggoesskrra")
        {
            var inputTokens = currentInput.Split(new[] { ' ', '|', '-', '>' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            bool onlyDataSet = inputTokens.Count() == 1;
            if (onlyDataSet)
            {
                string dataSet = inputTokens[0];
                overAll[dataSet] = new Dictionary<string, long>();

                // check if this dataSet allows you to move anything from the cache
                foreach (var cacheKey in cache.Keys)
                {
                    bool isMatch = dataSet == cacheKey;
                    if (isMatch)
                    {
                        bool newDataSet = !overAll.ContainsKey(dataSet);
                        if (newDataSet)
                        {
                            overAll[dataSet] = new Dictionary<string, long>();
                        }

                        var innerCacheDict = cache[cacheKey];
                        foreach (var innerDictKey in innerCacheDict.Keys)
                        {
                            overAll[dataSet][innerDictKey] = innerCacheDict[innerDictKey];
                        }
                    }
                }
            }
            else // dataKey -> dataSize | dataSet
            {
                string dataKey = inputTokens[0];
                long dataSize = long.Parse(inputTokens[1]);
                string dataSet = inputTokens[2];

                bool dataSetExists = overAll.ContainsKey(dataSet);
                if (dataSetExists)
                {
                    //apparently no keys will be copied so it will not exist
                    var outerDict = overAll[dataSet];
                    outerDict[dataKey] = dataSize;
                }
                else // send to cache
                {
                    bool newDataSetInCache = !cache.ContainsKey(dataSet);
                    if (newDataSetInCache)
                    {
                        cache[dataSet] = new Dictionary<string, long>();
                    }

                    cache[dataSet][dataKey] = dataSize;
                }
            }

            currentInput = Console.ReadLine();
        }


        //finding the top data set by sum of dataSize and printing (if any data sets at all)
        bool noneInOverAll = overAll.Keys.Count() == 0;
        if (noneInOverAll)
        {
            Console.WriteLine();
            return;
        }

        long topDataSize = 0;
        string topDataSet = string.Empty;

        //LINQ in a nested dict is really hard
        foreach (var dataSet in overAll.Keys)
        {
            long currentDataSizeTotal = 0;
            foreach (var dataSize in overAll[dataSet].Keys)
            {
                currentDataSizeTotal += overAll[dataSet][dataSize];
            }
            bool newTopDataSize = currentDataSizeTotal > topDataSize;
            if (newTopDataSize)
            {
                topDataSize = currentDataSizeTotal;
                topDataSet = dataSet;
            }
        }

        long totalSize = overAll[topDataSet].Sum(x => x.Value);

        Console.WriteLine($"Data Set: {topDataSet}, Total Size: {totalSize}");
        foreach (var dataKey in overAll[topDataSet])
        {
            Console.WriteLine($"$.{dataKey.Key}");
        }
    }
}