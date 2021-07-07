using TaskTracker_V1.Models;
using TaskTracker_V1.Services;
using TaskTracker_V1.Views;

namespace TaskTracker_V1.ViewModels
{
    // In MVVM, the ViewModel will contain commands, which are methods that can respond to specific activity in the view (i.e. button push)
    // For a data binding between button and viewModel, the button will define a command and command paramter
    // The data binding that targets the command property of the button has a source is a property in the viewModel of type ICommand
    public class TimeTaskPageViewModel : BaseViewModel
    {
        private TimeTaskPageViewModel _selectedTimeTask;
        private ITimeTaskStore _TimeTaskStore;
        private IPageService _pageService;

        private bool _isDataLoaded;

        public ObservableCollection<TimeTaskViewModel> TimeTasks { get; private set; }
            = new ObservableCollection<TimeTaskViewModel>();

        public TimeTaskPageViewModel SelectedTimeTask
        {
            get { return _selectedTimeTask; }
            set { SetValue(ref _selectedTimeTask, value); }
        }

        public ICommand LoadDataCommand { get; private set; }
        public ICommand AddTimeTaskCommand { get; private set; }
        public ICommand SelectTimeTaskCommand { get; private set; }
        public ICommand DeleteTimeTaskCommand { get; private set; }
        public ICommand StartTimeTaskTimerCommand { get; private set; }

        public TimeTaskPageViewModel(ITimeTaskStore TimeTaskStore, IPageService pageService)
        {
            _TimeTaskStore = TimeTaskStore;
            _pageService = pageService;

            LoadDataCommand = new Command(async () => await LoadData());
            AddTimeTaskCommand = new Command(async () => await AddTimeTask());
            SelectTimeTaskCommand = new Command<TimeTaskViewModel>(async c => await SelectTimeTask(c));
            DeleteTimeTaskCommand = new Command<TimeTaskViewModel>(async c => await DeleteTimeTask(c));
            StartTimeTaskTimerCommand = new Command<TimeTaskViewModel>(async c => await StartTimeTaskTimer());

            // Listen for a message sent indicating a TimeTask was added and then act on it
            MessagingCenter.Subscribe<TimeTasksDetailViewModel, TimeTask>
                (this, Events.TimeTaskAdded, OnTimeTaskAdded);

            // Listen for a message sent indicating a TimeTask was updated and then act on it
            MessagingCenter.Subscribe<TimeTasksDetailViewModel, TimeTask>
                (this, Events.TimeTaskUpdated, OnTimeTaskUpdated);
        }

        private void OnTimeTaskAdded(TimeTasksDetailViewModel source, TimeTask TimeTask)
        {
            TimeTasks.Add(new TimeTaskViewModel(TimeTask));
        }

        private void OnTimeTaskUpdated(TimeTasksDetailViewModel source, TimeTask TimeTask)
        {
            var TimeTaskInList = TimeTasks.Single(c => c.ID == TimeTask.ID);

            TimeTaskInList.ID = TimeTask.ID;
            TimeTaskInList.Name = TimeTask.Name;
            TimeTaskInList.IsBillable = TimeTask.IsBillable;
        }

        // Load all TimeTask data stored in DB
        private async Task LoadData()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;
            var TimeTasks = await _TimeTaskStore.GetTimeTasksAsync();
            foreach (var TimeTask in TimeTasks)
                this.TimeTasks.Add(new TimeTaskViewModel(TimeTask));
        }

        // Add button will trigger this call to a new page where TimeTask details can be entered
        private async Task AddTimeTask()
        {
            await _pageService.PushAsync(new TimeTaskDetailPage(new TimeTaskViewModel()));
        }

        // Navigate to the TimeTask details page to allow editing
        private async Task SelectTimeTask(TimeTaskViewModel TimeTask)
        {
            if (TimeTask == null)
                return;

            SelectedTimeTask = null;
            await _pageService.PushAsync(new TimeTaskDetailPage(TimeTask));
        }

        // Menu item will allow the selected TimeTask to be deleted from the TimeTasks list
        private async Task DeleteTimeTask(TimeTaskViewModel TimeTaskViewModel)
        {
            if (await _pageService.DisplayAlert("Warning", $"Are you sure you want to delete {TimeTaskViewModel.Name}?", "Yes", "No"))
            {
                TimeTasks.Remove(TimeTaskViewModel);

                var TimeTask = await _TimeTaskStore.GetTimeTask(TimeTaskViewModel.ID);
                await _TimeTaskStore.DeleteTimeTask(TimeTask);
            }
        }

        // Menu item will allow the selected TimeTask to be deleted from the TimeTasks list
        private async Task StartTimeTaskTimer()
        {
            SelectedTimeTask = null;
            await _pageService.PushAsync(new TimeEntryDetailPage(new TimeEntryViewModel()));
        }
    }
}