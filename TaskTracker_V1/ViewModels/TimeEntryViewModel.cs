using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker_V1.Models;

namespace TaskTracker_V1.ViewModels
{
    public class TimeEntryViewModel: BaseViewModel
    {
        /* Details from TimeEntry Model Class
         *         
        public int ID { get; set; }
        public int Total_Time { get; set; }
        public string Notes { get; set; }
        public DateTime Add_Date { get; set; }
        public Boolean Is_Deleted { get; set; }
        public int Task_ID { get; set; }
         * 
         */

        public int ID { get; set; }

        public TimeEntryViewModel() { }

        public TimeEntryViewModel(TimeEntry timeEntry) {

            ID = timeEntry.ID;
            _TotalTime = timeEntry.TotalTime;
            _Notes = timeEntry.Notes;
            _AddDate = timeEntry.AddDate;
            _IsDeleted = timeEntry.IsDeleted;
            _TaskID = timeEntry.TaskID;
        
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

        private string _Notes;
        public string Notes
        {
            get { return _Notes; }
            set
            {
                SetValue(ref _Notes, value);
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
