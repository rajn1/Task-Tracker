using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker_V1.Models;
using TaskTracker_V1.ViewModels;
using TaskTracker_V1.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TaskTracker_V1.Persistence;
using SQLite;
using System.Collections.ObjectModel;

/*
 * This is no longer needed code
 * Commenting it out to debug the remaining application
 * TODO: Once debugged, delete this cs file
 * 
namespace TaskTracker_V1.Views
{


    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        private SQLiteAsyncConnection _connection;

        public ItemsPage()
        {
            InitializeComponent();

            // Get a connection immediately as a gateway to the SQLite DB
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override async void OnAppearing()
        {

            await _connection.CreateTableAsync<TimeEntry>();
            var timeEntries = await _connection.Table<TimeEntry>().ToListAsync();
            taskListView.ItemsSource = _taskList; 

            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        //async void OnAdd(object sender, System.EventArgs e)
        //{
        //    var timeEntry = new TimeEntry { Total_Time = 0 };

        //    await _connection.InsertAsync(timeEntry);


        //    _timeEntries.Add(timeEntry);
        //}

        //async void OnDelete(object sender, System.EventArgs e)
        //{

        //    var timeEntry = _timeEntries[0];

        //    await _connection.DeleteAsync(timeEntry);

        //    _timeEntries.Remove(timeEntry);
        //}

        //async void OnUpdate(object sender, System.EventArgs e)
        //{
        //    var timeEntry = _timeEntries[0];
        //    timeEntry.Total_Time += 1; // Temporarily use a button to increate time by 1, see what happens

        //    await _connection.UpdateAsync(timeEntry);
        //}

    }
}
*/