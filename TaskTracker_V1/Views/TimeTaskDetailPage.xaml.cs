using TaskTracker_V1.Persistence;
using TaskTracker_V1.Services;
using TaskTracker_V1.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskTracker_V1.Views
{

    public partial class TimeTaskDetailPage : ContentPage
    {
        public TimeTaskDetailPage(TimeTaskViewModel viewModel)
        {
            InitializeComponent();
            var TimeTaskStore = new SQLiteTimeTaskStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            Title = (viewModel.Name == null) ? "New TimeTask" : "Edit TimeTask";
            BindingContext = new TimeTasksDetailViewModel(viewModel ?? new TimeTaskViewModel(), TimeTaskStore, pageService);
        }
    }
}