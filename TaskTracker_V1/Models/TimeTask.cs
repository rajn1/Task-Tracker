using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TaskTracker_V1.Models
{

    public class TimeTask
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        public Boolean IsBillable { get; set; }
        public int ClientID { get; set; }
        public DateTime AddDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Boolean IsDeleted { get; set; }

    }
}
