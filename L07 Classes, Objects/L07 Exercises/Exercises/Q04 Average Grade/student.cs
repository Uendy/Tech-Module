﻿using System;
using System.Collections.Generic;
using System.Linq;

    public class Student
    {
        public string Name { get; set; }
         
        public List<double> Grades { get; set; }
        
        public double Average => Math.Round(Grades.Average(), 2);
    }
