using SQLite;

namespace TaskTracker_V1.Persistence
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }

}
