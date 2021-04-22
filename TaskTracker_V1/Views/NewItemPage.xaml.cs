using System;
using System.Collections.Generic;
using System.ComponentModel;
using TaskTracker_V1.Models;
using TaskTracker_V1.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.Collections.ObjectModel;

namespace TaskTracker_V1.Views
{

    public partial class NewItemPage : ContentPage
    {

        ItemsViewModel _viewModel;

        private SQLiteAsyncConnection _connection;

        private ObservableCollection<TimeTask> _tasks;




        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }


        async void SaveCommand(object sender, System.EventArgs e)
        {


            var newTimeTask = new TimeTask { Name = taskName.Text  };

            await _connection.InsertAsync(newTimeTask);


            _tasks.Add(newTimeTask);
        }







    }

}