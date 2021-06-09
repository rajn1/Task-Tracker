using System;
using System.ComponentModel;
using System.Timers;
using Xamarin.Forms;

namespace TaskTracker_V1.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    // https://xamaringuyshow.com/2020/07/11/xamarin-forms-progress-ring-with-counter/
    [DesignTimeVisible(false)]
public partial class TimeEntryDetailPage : ContentPage
{
    private double _ProgressValue;
    public double ProgressValue
    {
        get
        {
            return _ProgressValue;
        }
        set
        {
            _ProgressValue = value;
            OnPropertyChanged();
        }
    }
    private double _Minimum;
    public double Minimum
    {
        get
        {
            return _Minimum;
        }
        set
        {
            _Minimum = value;
            OnPropertyChanged();
        }
    }
    private double _Maximum;
    public double Maximum
    {
        get
        {
            return _ProgressValue;
        }
        set
        {
            _ProgressValue = value;
            OnPropertyChanged();
        }
    }
    private Timer time = new Timer();
    private bool timerRunning;
    public TimeEntryDetailPage()
    {
        InitializeComponent();
        BindingContext = this;
        Minimum = 0;
        Maximum = 60;
        ProgressValue = 60;
        timerRunning = true;
        time.Start();
        Device.StartTimer(TimeSpan.FromSeconds(1), () =>
        {
            if (ProgressValue > Minimum)
            {
                ProgressValue--;
                return true;
            }
            else if (ProgressValue == Minimum)
            {
                time.Stop();
                timerRunning = false;
                //PerformOperationHere logic operation here.
                return false;
            }
            else
            {
                return true;
            }
        });
    }
}
}