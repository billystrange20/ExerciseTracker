using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseTracker2
{
    public class Weight
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime DateWeight { get; set; }
        public String UserWeight { get; set; }
    }
}
