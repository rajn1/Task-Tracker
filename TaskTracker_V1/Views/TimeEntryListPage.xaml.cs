using System;
using TaskTracker_V1.Persistence;
using TaskTracker_V1.Services;
using TaskTracker_V1.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskTracker_V1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimeEntryListPage : ContentPage
    {
        public TimeEntryListPage()
        {

            // Instantiate to load all Time Entries tied to a given TimeTask
            var TimeEntryStore = new SQLiteTimeEntryStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            ViewModel = new TimeEntryListPageViewModel(TimeEntryStore, pageService);
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            ViewModel.LoadDataCommand.Execute(null);
            base.OnAppearing();
        }
        void OnTimeTaskSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectTimeEntryCommand.Execute(e.SelectedItem);
        }
        public TimeEntryListPageViewModel ViewModel
        {
            get { return BindingContext as TimeEntryListPageViewModel; }
            set { BindingContext = value; }
        }


    }
}