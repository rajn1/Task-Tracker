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

    public class TimeTasksDetailViewModel
    {
        private readonly ITimeTaskStore _TimeTaskStore;
        private readonly IPageService _pageService;
        public TimeTask TimeTask { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public TimeTasksDetailViewModel(TimeTaskViewModel viewModel, ITimeTaskStore TimeTaskStore, IPageService pageService)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            _pageService = pageService;
            _TimeTaskStore = TimeTaskStore;
            SaveCommand = new Command(async () => await Save());
            TimeTask = new TimeTask
            {
                ID = viewModel.ID,
                Name = viewModel.Name,
                IsBillable = viewModel.IsBillable,
                ClientID = viewModel.ClientID
            };
        }

        async Task Save()
        {
            if (String.IsNullOrWhiteSpace(TimeTask.Name))
            {
                await _pageService.DisplayAlert("Error", "Please enter the name.", "OK");
                return;
            }
            // If this is a new TimeTask, add it to the DB by sending to messaging center
            if (TimeTask.ID == 0)
            {
                await _TimeTaskStore.AddTimeTask(TimeTask);
                MessagingCenter.Send(this, Events.TimeTaskAdded, TimeTask);
            }
            // If this is an existing TimeTask, send an update message to the messaging center
            else
            {
                await _TimeTaskStore.UpdateTimeTask(TimeTask);
                MessagingCenter.Send(this, Events.TimeTaskUpdated, TimeTask);
            }
            await _pageService.PopAsync();
        }
    }



}
