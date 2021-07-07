using TaskTracker_V1.Models;
using TaskTracker_V1.Services;

namespace TaskTracker_V1.ViewModels
{
    public class TimeEntryPageViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private readonly ITimeEntryStore _TimeEntryStore;
        private readonly IPageService _pageService;
        private Stopwatch stopwatch;
        private bool stopwatchRunning;
        private string progressValue;

        public string ProgressValue
        {
            get
            {
                return progressValue;
            }

            set
            {
                if (progressValue != value)
                {
                    progressValue = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("ProgressValue"));
                }
            }
        }

        public TimeEntry TimeEntry { get; private set; }

        public ICommand SaveCommand { get; private set; }
        public ICommand TimerStartCommand { get; private set; }
        public ICommand TimerStopCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public TimeEntryPageViewModel(TimeEntryViewModel viewModel, ITimeEntryStore TimeEntryStore, IPageService pageService)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            _pageService = pageService;
            _TimeEntryStore = TimeEntryStore;
            SaveCommand = new Command(async () => await Save());
            TimerStartCommand = new Command(() => TimerStart());
            TimerStopCommand = new Command(() => TimerStop());
            TimeEntry = new TimeEntry
            {
                ID = viewModel.ID,
                Notes = viewModel.Notes,
                TotalTime = viewModel.TotalTime,
                AddDate = viewModel.AddDate,
                UpdateDate = viewModel.UpdateDate,
                IsDeleted = viewModel.IsDeleted,
                TaskID = viewModel.TaskID
            };
        }

        private async Task Save()
        {
            if (TimeEntry.TotalTime == 0)
            {
                await _pageService.DisplayAlert("Error", "Time Entry of 0 seconds not allowed", "OK");
            }
            // Add new Time Entry if it is new
            if (TimeEntry.ID == 0)
            {
                await _TimeEntryStore.AddTimeEntry(TimeEntry);
                MessagingCenter.Send(this, Events.TimeEntryAdded, TimeEntry);
            }
            // If it's an existing TimeEntry, send an update message to the DB
            else
            {
                await _TimeEntryStore.UpdateTimeEntry(TimeEntry);
                MessagingCenter.Send(this, Events.TimeEntryUpdated, TimeEntry);
            }
            await _pageService.PopAsync();
        }

        private void TimerStart()
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
            stopwatchRunning = true;

            Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
            {
                ProgressValue = stopwatch.Elapsed.ToString("mm\\:ss\\.ff");
                if (!stopwatchRunning)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            });
        }

        private void TimerStop()
        {
            // Set variable to stop the timer kicked off by TimerStart()
            stopwatchRunning = false;
            TimeEntry.TotalTime = (int)stopwatch.ElapsedMilliseconds;
        }
    }
}