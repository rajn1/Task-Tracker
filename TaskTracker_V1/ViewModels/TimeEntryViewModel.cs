using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker_V1.Models;
using Xamarin.Forms;


// https://medium.com/swlh/xamarin-forms-mvvm-how-to-work-with-sqlite-db-c-xaml-26fcae303edd
namespace TaskTracker_V1.ViewModels
{
    // Provides all needed details to access a client
    // By extending the BaseViewModel, we can implement INotifyPropertyChanged for all clients, allowing the VewModel (VM) to be notified of changes
    public class TimeEntryViewModel : BaseViewModel
    {
        public int ID { get; set; }

        public TimeEntryViewModel() { }

        public TimeEntryViewModel(TimeEntry TimeEntry)
        {

            ID = TimeEntry.ID;
            _Notes = TimeEntry.Notes;
            _TotalTime = TimeEntry.TotalTime;
            _AddDate = TimeEntry.AddDate;
            _UpdateDate = TimeEntry.UpdateDate;
            _IsDeleted = TimeEntry.IsDeleted;
            _TaskID = TimeEntry.TaskID;

        }

        private string _Notes;
        public string Notes
        {
            get { return _Notes; }
            set
            {
                SetValue(ref _Notes, value);
            }
        }


        private int _TotalTime;
        public int TotalTime
        {
            get { return _TotalTime; }
            set
            {
                SetValue(ref _TotalTime, value);
            }
        }

        private DateTime _AddDate;
        public DateTime AddDate
        {
            get { return _AddDate; }
            set
            {
                SetValue(ref _AddDate, value);
            }
        }

        private Boolean _IsDeleted;
        public Boolean IsDeleted
        {
            get { return _IsDeleted; }
            set
            {
                SetValue(ref _IsDeleted, value);
            }
        }

        private DateTime _UpdateDate;
        public DateTime UpdateDate
        {
            get { return _UpdateDate; }
            set
            {
                SetValue(ref _UpdateDate, value);
            }
        }

        private int _TaskID;
        public int TaskID
        {
            get { return _TaskID; }
            set
            {
                SetValue(ref _TaskID, value);
            }
        }

    }


}
