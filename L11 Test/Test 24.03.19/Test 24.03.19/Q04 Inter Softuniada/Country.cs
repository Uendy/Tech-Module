using System.Collections.Generic;
public class Country
{
    public string Name { get; set; }
    public Dictionary<string, long> CoderAndPoints {get; set;} // key = participant, // value = points
    public long TotalPoints { get; set; }
}