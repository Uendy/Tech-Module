using System;
using System.Collections.Generic;
using System.Linq;
public class Town
{
    public string Name { get; set; }
    public int Size { get; set; }
    public List<Student> Students { get; set; }
    public List<Group> Groups { get; set; }
}