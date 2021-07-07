using System;
using System.ComponentModel;
using System.Diagnostics;
using TaskTracker_V1.Persistence;
using TaskTracker_V1.Services;
using TaskTracker_V1.ViewModels;
using Xamarin.Forms;

namespace TaskTracker_V1.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    // https://xamaringuyshow.com/2020/07/11/xamarin-forms-progress-ring-with-counter/
    [DesignTimeVisible(false)]
    public partial class TimeEntryDetailPage : ContentPage
    {

        public TimeEntryDetailPage(TimeEntryViewModel viewModel)
        {

            InitializeComponent();
            var TimeEntryStore = new SQLiteTimeEntryStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            Title = (viewModel.ID == 0) ? "New Time Entry" : "Edit Time Entry";
            BindingContext = new TimeEntryPageViewModel(viewModel ?? new TimeEntryViewModel(), TimeEntryStore, pageService);

        }

    }
}