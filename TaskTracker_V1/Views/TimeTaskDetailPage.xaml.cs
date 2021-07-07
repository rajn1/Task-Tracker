using TaskTracker_V1.Persistence;
using TaskTracker_V1.Services;
using TaskTracker_V1.ViewModels;

namespace TaskTracker_V1.Views
{
    public partial class TimeTaskDetailPage : ContentPage
    {
        // Temp variable to store selected client's ID
        private int clientID_selected;

        private void Handle_Tapped(object sender, System.EventArgs e)
        {
            // Make new page a variable so that we can pull out the selected ID
            var clientSelectionPage = new ClientSelectionPage();
            // Use the new Item selection method to pull in the listView from the Selection page, and then pull in the name of the client being selected using casting
            clientSelectionPage.ClientList.ItemSelected += (source, args) =>
            {
                // Safe because this is guarenteed to always be a client
                var client = (ClientViewModel)args.SelectedItem;
                clientName.Text = client.Name;
                clientID_selected = client.ID;
                Navigation.PopAsync();
            };

            Navigation.PushAsync(clientSelectionPage);
        }

        public TimeTaskDetailPage(TimeTaskViewModel viewModel)
        {
            InitializeComponent();

            var TimeTaskStore = new SQLiteTimeTaskStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            Title = (viewModel.Name == null) ? "New TimeTask" : "Edit TimeTask";
            viewModel.ClientID = clientID_selected;
            BindingContext = new TimeTasksDetailViewModel(viewModel ?? new TimeTaskViewModel(), TimeTaskStore, pageService);
        }
    }
}