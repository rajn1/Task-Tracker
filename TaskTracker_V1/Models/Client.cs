using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TaskTracker_V1.Models
{
    public class Client
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime AddDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Boolean IsDeleted { get; set; }

    }
}
