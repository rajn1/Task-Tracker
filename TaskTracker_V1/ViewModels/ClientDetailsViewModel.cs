using TaskTracker_V1.Models;
using TaskTracker_V1.Services;

namespace TaskTracker_V1.ViewModels
{
    public class ClientsDetailViewModel
    {
        private readonly IClientStore _ClientStore;
        private readonly IPageService _pageService;
        public Client Client { get; private set; }
        public ICommand SaveCommand { get; private set; }

        public ClientsDetailViewModel(ClientViewModel viewModel, IClientStore ClientStore, IPageService pageService)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            _pageService = pageService;
            _ClientStore = ClientStore;
            SaveCommand = new Command(async () => await Save());
            Client = new Client
            {
                ID = viewModel.ID,
                Name = viewModel.Name,
                IsFavorite = viewModel.IsFavorite,
            };
        }

        private async Task Save()
        {
            if (String.IsNullOrWhiteSpace(Client.Name))
            {
                await _pageService.DisplayAlert("Error", "Please enter the name.", "OK");
                return;
            }
            // If this is a new client, add it to the DB by sending to messaging center
            if (Client.ID == 0)
            {
                await _ClientStore.AddClient(Client);
                MessagingCenter.Send(this, Events.ClientAdded, Client);
            }
            // If this is an existing client, send an update message to the messaging center
            else
            {
                await _ClientStore.UpdateClient(Client);
                MessagingCenter.Send(this, Events.ClientUpdated, Client);
            }
            await _pageService.PopAsync();
        }
    }
}