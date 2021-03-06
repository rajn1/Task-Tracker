using TaskTracker_V1.Persistence;
using TaskTracker_V1.Services;
using TaskTracker_V1.ViewModels;

namespace TaskTracker_V1.Views
{
    public partial class ClientDetailPage : ContentPage
    {
        public ClientDetailPage(ClientViewModel viewModel)
        {
            InitializeComponent();
            var ClientStore = new SQLiteClientStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            Title = (viewModel.Name == null) ? "New Client" : "Edit Client";
            BindingContext = new ClientsDetailViewModel(viewModel ?? new ClientViewModel(), ClientStore, pageService);
        }
    }
}