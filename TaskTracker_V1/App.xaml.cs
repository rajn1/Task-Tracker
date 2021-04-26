using System;
using TaskTracker_V1.Services;
using TaskTracker_V1.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace TaskTracker_V1
{
    public partial class App : Application
    {



        // Public taskList in the app page allows any pages in the project hit/access this taskList
        public ObservableCollection<TimeTask> _taskList { get; set; }


        // TO make it accessible, make a ViewModelBase to forward the property to any videoModel it derives from
        // http://www.ronaldrosier.net/Blog/2014/01/27/access_data_between_pages_with_observablecollection
        public abstract class ViewModelBase // : INotifyPropertyChanged
        {
            public ObservableCollection<TimeTask> _taskList
            {
                get
                {
                    return ((App)Application.Current)._taskList;
                }
            }

            // INotifyPropertyChanged implementation
        }

        public App()
        {

            _taskList = new ObservableCollection<TimeTask>();

            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
