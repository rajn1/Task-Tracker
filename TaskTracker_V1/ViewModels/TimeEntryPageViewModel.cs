using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskTracker_V1.Models;
using TaskTracker_V1.Services;
using Xamarin.Forms;

namespace TaskTracker_V1.ViewModels
{
    class TimeEntryPageViewModel : BaseViewModel
    {

        private readonly ITimeEntryStore _TimeEntryStore;
        private readonly IPageService _pageService;
        public TimeEntry TimeEntry { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public TimeEntryPageViewModel(TimeEntryViewModel viewModel, ITimeEntryStore TimeEntryStore, IPageService pageService)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            _pageService = pageService;
            _TimeEntryStore = TimeEntryStore;
            SaveCommand = new Command(async () => await Save());
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

        async Task Save()
        {
            if (TimeEntry.TotalTime == 0)
            {
                await _pageService.DisplayAlert("Error", "Time Entry of 0 seconds not allowed", "OK");
            }
            // Add new Time ENtry if it is new
            if(TimeEntry.ID == 0)
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
    }

}
