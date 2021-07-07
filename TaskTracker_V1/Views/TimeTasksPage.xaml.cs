using TaskTracker_V1.Persistence;
using TaskTracker_V1.Services;
using TaskTracker_V1.ViewModels;

namespace TaskTracker_V1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimeTasksPage : ContentPage
    {
        public TimeTasksPage()
        {
            var TimeTaskStore = new SQLiteTimeTaskStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            ViewModel = new TimeTaskPageViewModel(TimeTaskStore, pageService);
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            ViewModel.LoadDataCommand.Execute(null);
            base.OnAppearing();
        }

        private void OnTimeTaskSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectTimeTaskCommand.Execute(e.SelectedItem);
        }

        public TimeTaskPageViewModel ViewModel
        {
            get { return BindingContext as TimeTaskPageViewModel; }
            set { BindingContext = value; }
        }
    }
}