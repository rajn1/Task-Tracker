using TaskTracker_V1.Persistence;
using TaskTracker_V1.Services;
using TaskTracker_V1.ViewModels;

namespace TaskTracker_V1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientsPage : ContentPage
    {
        public ClientsPage()
        {
            var clientStore = new SQLiteClientStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            ViewModel = new ClientsPageViewModel(clientStore, pageService);
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            ViewModel.LoadDataCommand.Execute(null);
            base.OnAppearing();
        }

        private void OnClientSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectClientCommand.Execute(e.SelectedItem);
        }

        public ClientsPageViewModel ViewModel
        {
            get { return BindingContext as ClientsPageViewModel; }
            set { BindingContext = value; }
        }
    }
}