using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskTracker_V1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimeEntryListPage : ContentPage
    {
        public TimeEntryListPage()
        {

            // Instantiate to load all Time Entries tied to a given TimeTask
            // Mimic structure of TimeTasksPage
            // Build off TimeEntryListPageViewModel
            InitializeComponent();
        }
    }
}