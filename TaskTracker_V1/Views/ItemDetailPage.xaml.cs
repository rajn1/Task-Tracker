using System.ComponentModel;
using TaskTracker_V1.ViewModels;
using Xamarin.Forms;

namespace TaskTracker_V1.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}