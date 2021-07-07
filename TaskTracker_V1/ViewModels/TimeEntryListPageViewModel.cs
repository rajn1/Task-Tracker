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

namespace TaskTracker_V1.ViewModels
{
    public class TimeEntryListPageViewModel : BaseViewModel
    {

        // Pending Instantiation to ensure this class acts as a list of time entries tied to a task
        // Link up to MessageCenter to react when a new TimeEntry is added or Updated

        private TimeEntryListPageViewModel _selectedTimeEntry;
        private ITimeEntryStore _TimeEntryStore;
        private IPageService _pageService;

        private bool _isDataLoaded;

        public ObservableCollection<TimeEntryViewModel> TimeEntries { get; private set; }
        = new ObservableCollection<TimeEntryViewModel>();

        public TimeEntryListPageViewModel SelectedTimeEntry
        {
            get { return _selectedTimeEntry; }
            set { SetValue(ref _selectedTimeEntry, value); }
        }

        public ICommand LoadDataCommand { get; private set; }
        public ICommand AddTimeEntryCommand { get; private set; }
        public ICommand SelectTimeEntryCommand { get; private set; }
        public ICommand DeleteTimeEntryCommand { get; private set; }

        public TimeEntryListPageViewModel(ITimeEntryStore TimeEntryStore, IPageService pageService)
        {
            _TimeEntryStore = TimeEntryStore;
            _pageService = pageService;

            LoadDataCommand = new Command(async () => await LoadData());
            AddTimeEntryCommand = new Command<TimeEntryViewModel>(async (c) => await AddTimeEntry(c));
            SelectTimeEntryCommand = new Command<TimeEntryViewModel>(async c => await SelectTimeEntry(c));
            DeleteTimeEntryCommand = new Command<TimeEntryViewModel>(async c => await DeleteTimeEntry(c));


            // Listen for a message sent indicating a TimeEntry was added and then act on it
            MessagingCenter.Subscribe<TimeEntryPageViewModel, TimeEntry>
                (this, Events.TimeEntryAdded, OnTimeEntryAdded);

            // Listen for a message sent indicating a TimeEntry was updated and then act on it
            MessagingCenter.Subscribe<TimeEntryPageViewModel, TimeEntry>
                (this, Events.TimeEntryUpdated, OnTimeEntryUpdated);
        }
        private void OnTimeEntryAdded(TimeEntryPageViewModel source, TimeEntry TimeEntry)
        {
            TimeEntries.Add(new TimeEntryViewModel(TimeEntry));
        }

        private void OnTimeEntryUpdated(TimeEntryPageViewModel source, TimeEntry TimeEntry)
        {
            var TimeEntryInList = TimeEntries.Single(c => c.ID == TimeEntry.ID);

            TimeEntryInList.ID = TimeEntry.ID;
            TimeEntryInList.TotalTime = TimeEntry.TotalTime;
        }

        // Load all TimeEntry data stored in DB
        private async Task LoadData()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;
            var TimeEntries = await _TimeEntryStore.GetTimeEntriesAsync();
            foreach (var TimeEntry in TimeEntries)
                this.TimeEntries.Add(new TimeEntryViewModel(TimeEntry));
        }
        // Add button will trigger this call to a new page where TimeEntry details can be entered
        private async Task AddTimeEntry(TimeEntryViewModel TimeEntry)
        {
            await _pageService.PushAsync(new TimeEntryDetailPage(TimeEntry));
        }

        // Navigate to the TimeTask details page to allow editing
        private async Task SelectTimeEntry(TimeEntryViewModel TimeEntry)
        {
            if (TimeEntry == null)
                return;

            SelectedTimeEntry = null;
            await _pageService.PushAsync(new TimeEntryDetailPage(TimeEntry));
        }

        // Menu item will allow the selected TimeEntry to be deleted from the TimeEntries list
        private async Task DeleteTimeEntry(TimeEntryViewModel TimeEntryViewModel)
        {
            if (await _pageService.DisplayAlert("Warning", $"Are you sure you want to delete this time Entry?", "Yes", "No"))
            {
                TimeEntries.Remove(TimeEntryViewModel);

                var TimeEntry = await _TimeEntryStore.GetTimeEntry(TimeEntryViewModel.ID);
                await _TimeEntryStore.DeleteTimeEntry(TimeEntry);
            }
        }
    }
}
