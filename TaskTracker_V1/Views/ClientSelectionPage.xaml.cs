using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TaskTracker_V1.ViewModels;
using TaskTracker_V1.Persistence;
using TaskTracker_V1.Services;


namespace TaskTracker_V1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientSelectionPage : ContentPage
    {
        public ClientSelectionPage()
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

        public ClientsPageViewModel ViewModel
        {
            get { return BindingContext as ClientsPageViewModel; }
            set { BindingContext = value; }
        }

        // TODO : Convert this to an actual accessible list of names / figure out what to do about the Foreign Key ID needed
        public ListView ClientList
        {
            get { return listView; }
        }
    }
}