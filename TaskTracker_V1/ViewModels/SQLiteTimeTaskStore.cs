using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskTracker_V1.Models;
using SQLite;
using TaskTracker_V1.Persistence;

namespace TaskTracker_V1.ViewModels
{
    public class SQLiteTimeTaskStore : ITimeTaskStore
    {
        private SQLiteAsyncConnection _connection;
        public SQLiteTimeTaskStore(ISQLiteDb db)
        {
            _connection = db.GetConnection();
            _connection.CreateTableAsync<TimeTask>();
        }
        // Convert TimeTasks stored in SQL DB to a list
        public async Task<IEnumerable<TimeTask>> GetTimeTasksAsync()
        {
            return await _connection.Table<TimeTask>().ToListAsync();
        }
        // Delete TimeTask from SQL DB
        public async Task DeleteTimeTask(TimeTask TimeTask)
        {
            await _connection.DeleteAsync(TimeTask);
        }
        // Add TimeTask to SQL DB
        public async Task AddTimeTask(TimeTask TimeTask)
        {
            await _connection.InsertAsync(TimeTask);
        }
        // Update edited TimeTask details in SQL DB
        public async Task UpdateTimeTask(TimeTask TimeTask)
        {
            await _connection.UpdateAsync(TimeTask);
        }
        // Return details of a given TimeTask using provided ID
        public async Task<TimeTask> GetTimeTask(int ID)
        {
            return await _connection.FindAsync<TimeTask>(ID);
        }
    }
}
