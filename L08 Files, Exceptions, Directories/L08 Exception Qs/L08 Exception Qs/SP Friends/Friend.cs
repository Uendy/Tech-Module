using System;
using System.Globalization;
public class Friend
{
    public string Name { get; set; }

    public DateTime LastTalk { get; set; }

    public TimeSpan TalkFrequency { get; set; }

    public TimeSpan DaysUntilTalk { get; set; }

    public bool NeedToTalk { get; set; }
}