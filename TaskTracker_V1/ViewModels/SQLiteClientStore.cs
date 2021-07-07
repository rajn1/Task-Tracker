using TaskTracker_V1.Models;
using TaskTracker_V1.Persistence;

namespace TaskTracker_V1.ViewModels
{
    public class SQLiteClientStore : IClientStore
    {
        private SQLiteAsyncConnection _connection;

        public SQLiteClientStore(ISQLiteDb db)
        {
            _connection = db.GetConnection();
            _connection.CreateTableAsync<Client>();
        }

        // Convert Clients stored in SQL DB to a list
        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            return await _connection.Table<Client>().ToListAsync();
        }

        // Delete Client from SQL DB
        public async Task DeleteClient(Client Client)
        {
            await _connection.DeleteAsync(Client);
        }

        // Add Client to SQL DB
        public async Task AddClient(Client Client)
        {
            await _connection.InsertAsync(Client);
        }

        // Update edited client details in SQL DB
        public async Task UpdateClient(Client Client)
        {
            await _connection.UpdateAsync(Client);
        }

        // Return details of a given client using provided ID
        public async Task<Client> GetClient(int ID)
        {
            return await _connection.FindAsync<Client>(ID);
        }
    }
}