using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker_V1.Models;
using Xamarin.Forms;


// https://medium.com/swlh/xamarin-forms-mvvm-how-to-work-with-sqlite-db-c-xaml-26fcae303edd
namespace TaskTracker_V1.ViewModels
{
    // Provides all needed details to access a Time Task
    // By extending the BaseViewModel, we can implement INotifyPropertyChanged for all tasks, allowing the VewModel (VM) to be notified of changes
    public class TimeTaskViewModel : BaseViewModel
    {
        public int ID { get; set; }

        public TimeTaskViewModel() { }

        public TimeTaskViewModel(TimeTask TimeTask)
        {

            ID = TimeTask.ID;
            _Name = TimeTask.Name;
            _IsBillable = TimeTask.IsBillable;
            _ClientID = TimeTask.ClientID;
            _AddDate = TimeTask.AddDate;
            _UpdateDate = TimeTask.UpdateDate;
            _IsDeleted = TimeTask.IsDeleted;

        }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                SetValue(ref _Name, value);
            }
        }


        private Boolean _IsBillable;
        public Boolean IsBillable
        {
            get { return _IsBillable; }
            set
            {
                SetValue(ref _IsBillable, value);
            }
        }

        private int _ClientID;
        public int ClientID
        {
            get { return _ClientID; }
            set
            {
                SetValue(ref _ClientID, value);
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

        public string clientName
        {
            get { return _ClientID.ToString(); }
        
        }

    }


}
