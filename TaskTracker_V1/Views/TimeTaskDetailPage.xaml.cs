using TaskTracker_V1.Persistence;
using TaskTracker_V1.Services;
using TaskTracker_V1.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskTracker_V1.Views
{

    public partial class TimeTaskDetailPage : ContentPage
    {

        void Handle_Tapped(object sender, System.EventArgs e)
        {
            // Make new page a variable so that we can pull out the selected ID
            var clientSelectionPage = new ClientSelectionPage();
            // Use the new Item selection method to pull in the listView from the Selection page, and then pull in the name of the client being selected
            clientSelectionPage.ClientList.ItemSelected += (source, args) =>
            {
                clientName.Text = args.SelectedItem.ToString();
                Navigation.PopAsync();
            };

            Navigation.PushAsync(clientSelectionPage);
        }

        public TimeTaskDetailPage(TimeTaskViewModel viewModel)
        {
            InitializeComponent();
            var ClientStore = new SQLiteClientStore(DependencyService.Get<ISQLiteDb>());
            var TimeTaskStore = new SQLiteTimeTaskStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            Title = (viewModel.Name == null) ? "New TimeTask" : "Edit TimeTask";
            BindingContext = new TimeTasksDetailViewModel(viewModel ?? new TimeTaskViewModel(), TimeTaskStore, ClientStore, pageService);
        }
    }
}