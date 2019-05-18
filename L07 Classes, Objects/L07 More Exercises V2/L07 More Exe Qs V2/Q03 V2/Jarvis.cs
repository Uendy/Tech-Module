using System.Collections.Generic;
public class Robot
{
    public long Capacity { get; set; }
    public Head Head { get; set; }
    public Torso Torso { get; set; }
    public List<Arm> Arms { get; set; }
    public List<Leg> Legs { get; set; }
}