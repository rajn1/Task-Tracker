using System;
using Xamarin.Forms;

namespace TaskTracker_V1.ViewModels
{
    public class ValueProgressBarConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //if 30 sec is your maximum time
            // return (double)value/30;

            //if 60 sec if your maximum time
            return (double)value / 60;

        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return new NotImplementedException();
        }
    }
}
