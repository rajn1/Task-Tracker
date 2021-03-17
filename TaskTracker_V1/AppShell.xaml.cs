using System;
using System.Collections.Generic;
using TaskTracker_V1.ViewModels;
using TaskTracker_V1.Views;
using Xamarin.Forms;

namespace TaskTracker_V1
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
