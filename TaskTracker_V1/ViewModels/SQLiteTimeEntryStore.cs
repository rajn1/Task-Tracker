using TaskTracker_V1.Models;
using TaskTracker_V1.Persistence;

namespace TaskTracker_V1.ViewModels
{
    public class SQLiteTimeEntryStore : ITimeEntryStore
    {
        private SQLiteAsyncConnection _connection;

        public SQLiteTimeEntryStore(ISQLiteDb db)
        {
            _connection = db.GetConnection();
            _connection.CreateTableAsync<TimeEntry>();
        }

        // Convert TimeEntrys stored in SQL DB to a list
        public async Task<IEnumerable<TimeEntry>> GetTimeEntriesAsync()
        {
            return await _connection.Table<TimeEntry>().ToListAsync();
        }

        // Delete TimeEntry from SQL DB
        public async Task DeleteTimeEntry(TimeEntry TimeEntry)
        {
            await _connection.DeleteAsync(TimeEntry);
        }

        // Add TimeEntry to SQL DB
        public async Task AddTimeEntry(TimeEntry TimeEntry)
        {
            await _connection.InsertAsync(TimeEntry);
        }

        // Update edited TimeEntry details in SQL DB
        public async Task UpdateTimeEntry(TimeEntry TimeEntry)
        {
            await _connection.UpdateAsync(TimeEntry);
        }

        // Return details of a given TimeEntry using provided ID
        public async Task<TimeEntry> GetTimeEntry(int ID)
        {
            return await _connection.FindAsync<TimeEntry>(ID);
        }
    }
}