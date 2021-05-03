using System;
using SQLite;

namespace TaskTracker_V1.Models
{
    public class Client
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        public DateTime AddDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Boolean IsDeleted { get; set; }
        public Boolean IsFavorite { get; set; }

    }
}
