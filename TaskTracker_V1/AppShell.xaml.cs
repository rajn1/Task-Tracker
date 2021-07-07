using TaskTracker_V1.Views;

namespace TaskTracker_V1
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ClientDetailPage), typeof(ClientDetailPage));
        }
    }
}