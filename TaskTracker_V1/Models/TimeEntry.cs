using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TaskTracker_V1.Models
{
    // Classes meant to represent the data structure for Time Entries 
    // TODO: Add Foreign Keys
    public class TimeEntry
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int TotalTime { get; set; }
        public string Notes { get; set; }
        public DateTime AddDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Boolean IsDeleted { get; set; }
        public int TaskID { get; set; }


    }
}
