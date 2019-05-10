using System.Collections.Generic;
using System.Linq;
public class Student
{
    // name, list of grades and average grade
    public string Name { get; set; }
    public List<double> Grades { get; set; }
    public double AverageGrade => Grades.Average();

}