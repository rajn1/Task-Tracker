using System;
using System.Collections.Generic;
using System.ComponentModel;
using TaskTracker_V1.Models;
using TaskTracker_V1.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskTracker_V1.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}