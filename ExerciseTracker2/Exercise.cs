using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseTracker2
{
    public class Exercise
    { 
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public String ExName { get; set; }
        public String ExType { get; set; }
        public String AvgWeight { get; set; }
        public String PBWeight { get; set; }
        
    }
}
