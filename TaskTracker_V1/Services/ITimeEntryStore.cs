namespace TaskTracker_V1.Models
{
    public interface ITimeEntryStore
    {
        Task<IEnumerable<TimeEntry>> GetTimeEntriesAsync();

        Task<TimeEntry> GetTimeEntry(int id);

        Task AddTimeEntry(TimeEntry TimeEntry);

        Task UpdateTimeEntry(TimeEntry TimeEntry);

        Task DeleteTimeEntry(TimeEntry TimeEntry);
    }
}