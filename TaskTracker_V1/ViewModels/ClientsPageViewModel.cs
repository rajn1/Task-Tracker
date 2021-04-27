using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskTracker_V1.Models;
using TaskTracker_V1.Services;
using TaskTracker_V1.Views;
using Xamarin.Forms;
using Client = TaskTracker_V1.Models.Client;

namespace TaskTracker_V1.ViewModels
{
    public class ClientsPageViewModel : BaseViewModel
    {
        private ClientViewModel _selectedClient;
        private IClientStore _ClientStore;
        private IPageService _pageService;

        private bool _isDataLoaded;

        public ObservableCollection<ClientViewModel> _ClientList { get; private set; }
            = new ObservableCollection<ClientViewModel>();

        public ClientViewModel SelectedClient
        {
            get { return _selectedClient; }
            set { SetValue(ref _selectedClient, value); }
        }

        public ICommand LoadDataCommand { get; private set; }
        public ICommand AddClientCommand { get; private set; }
        public ICommand SelectClientCommand { get; private set; }
        public ICommand DeleteClientCommand { get; private set; }

        public ClientsPageViewModel(IClientStore ClientStore, IPageService pageService)
        {
            _ClientStore = ClientStore;
            _pageService = pageService;

            LoadDataCommand = new Command(async () => await LoadData());
            AddClientCommand = new Command(async () => await AddClient());
            SelectClientCommand = new Command<ClientViewModel>(async c => await SelectClient(c));
            DeleteClientCommand = new Command<ClientViewModel>(async c => await DeleteClient(c));

            MessagingCenter.Subscribe<ClientsDetailViewModel, Client>
                (this, Events.ClientAdded, OnClientAdded);

            MessagingCenter.Subscribe<ClientsDetailViewModel, Client>
                (this, Events.ClientUpdated, OnClientUpdated);
        }


        private void OnClientAdded(ClientsDetailViewModel source, Client client)
        {
            _ClientList.Add(new ClientViewModel(client));
        }

        private void OnClientUpdated(ClientsDetailViewModel source, Client Client)
        {
            var ClientInList = _ClientList.Single(c => c.ID == Client.ID);

            ClientInList.ID = Client.ID;
            ClientInList.Name = Client.Name;
            ClientInList.IsFavorite = Client.IsFavorite;
        }

        // Load all client data stored in DB
        private async Task LoadData()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;
            var Clients = await _ClientStore.GetClientsAsync();
            foreach (var Client in Clients)
                _ClientList.Add(new ClientViewModel(Client));
        }

        // Add button will trigger this call to a new page where Client details can be entered
        private async Task AddClient()
        {
            await _pageService.PushAsync(new ClientDetailPage(new ClientViewModel()));
        }

        // Navigate to the Client details page to allow editing
        private async Task SelectClient(ClientViewModel Client)
        {
            if (Client == null)
                return;

            SelectedClient = null;
            await _pageService.PushAsync(new ClientDetailPage(Client));
        }

        // Menu item will allow the selected client to be deleted from the Clients list
        private async Task DeleteClient(ClientViewModel ClientViewModel)
        {
            if (await _pageService.DisplayAlert("Warning", $"Are you sure you want to delete {ClientViewModel.Name}?", "Yes", "No"))
            {
                _ClientList.Remove(ClientViewModel);

                var Client = await _ClientStore.GetClient(ClientViewModel.ID);
                await _ClientStore.DeleteClient(Client);
            }
        }

        private async Task EditClient(ClientViewModel ClientViewModel)
        {
                // TBD
        }
    }
}
