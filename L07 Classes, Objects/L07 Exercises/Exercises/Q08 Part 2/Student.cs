using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q08_Part_2
{
    public class Student
    {
        public string StudentName
        {
            get; set;
        }

        public List<DateTime> AttendingDates
        {
            get; set;
        }

        public List<string> Comment
        {
            get; set;
        }
    }
}
