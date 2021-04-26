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

namespace TaskTracker_V1.Views
{

    // Classes meant to represent the data structure for SQL tables
    public class TimeEntry : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int Total_Time { get; set; }
        public string Notes { get; set; }
        public DateTime Add_Date { get; set; }
        public Boolean Is_Deleted { get; set; }
        public int Task_ID { get; set; }

        public event PropertyChangedEventHandler PropertyChanged; // Notify Subscribers when something has changed with this table
    }

    public class TimeTask : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public Boolean Is_Billable { get; set; }
        public int Client_ID { get; set; }
        public DateTime Add_Date { get; set; }
        public DateTime Update_Date { get; set; }
        public Boolean Is_Deleted { get; set; }

        public event PropertyChangedEventHandler PropertyChanged; // Notify Subscribers when something has changed with this table
    }

    public class Client : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Add_Date { get; set; }
        public DateTime Update_Date { get; set; }
        public Boolean Is_Deleted { get; set; }

        public event PropertyChangedEventHandler PropertyChanged; // Notify Subscribers when something has changed with this table
    }


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