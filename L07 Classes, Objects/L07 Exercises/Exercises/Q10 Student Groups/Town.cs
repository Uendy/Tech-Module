using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q10_Student_Groups
{
    public class Town
    {
        public string Name { get; set; }

        public int SeatCount { get; set; }

        public int SeatsTaken { get; set; }

        public List<Student> ListOfStudents { get; set; }

        public List<Group> ListOfGroups { get; set; }
    }
}
