namespace TaskTracker_V1.Models
{
    public interface IClientStore
    {
        Task<IEnumerable<Client>> GetClientsAsync();

        Task<Client> GetClient(int id);

        Task AddClient(Client Client);

        Task UpdateClient(Client Client);

        Task DeleteClient(Client Client);
    }
}