/*
 *
 * This is no longer needed code
 * Commenting it out to debug the remaining application
 * TODO: Once debugged, delete this cs file
 *

namespace TaskTracker_V1.Views
{
    public partial class NewItemPage : ContentPage
    {
        private SQLiteAsyncConnection _connection;

        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }

        public async void SaveCommand(object sender, System.EventArgs e)
        {
            var newTimeTask = new TimeTask { Name = taskName.Text  };

            await _connection.InsertAsync(newTimeTask);
           }
    }
}

*/