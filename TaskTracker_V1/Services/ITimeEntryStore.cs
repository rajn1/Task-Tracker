using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker_V1.Models
{
    public interface ITimeEntryStore
    {
        Task<IEnumerable<TimeEntry>> GetTimeEntrysAsync();
        Task<TimeEntry> GetTimeEntry(int id);
        Task AddTimeEntry(TimeEntry TimeEntry);
        Task UpdateTimeEntry(TimeEntry TimeEntry);
        Task DeleteTimeEntry(TimeEntry TimeEntry);
    }

}
