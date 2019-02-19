using System.Collections.Generic;
using System.Linq;

public class Library
{
    public string Name { get; set; }

    public List<Books> Books { get; set; }

    public SortedDictionary<string, double> Dict { get; set; }

   // public Dictionary<string, double> Final => Dict.OrderByDescending(x => x.Value).ThenBy(x => x.Key); 
}
