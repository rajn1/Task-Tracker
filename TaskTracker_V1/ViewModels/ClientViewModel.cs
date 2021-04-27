using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker_V1.Models;


// https://medium.com/swlh/xamarin-forms-mvvm-how-to-work-with-sqlite-db-c-xaml-26fcae303edd
namespace TaskTracker_V1.ViewModels
{
    public class ClientViewModel: BaseViewModel
    {
        /* Details from Client Model Class
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

        public ClientViewModel() { }

        public ClientViewModel(Client Client) {

            ID = Client.ID;
            _Name = Client.Name;
            _AddDate = Client.AddDate;
            _IsDeleted = Client.IsDeleted; 
            _UpdateDate = Client.UpdateDate;
            _IsFavorite = Client.IsFavorite;

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

        private Boolean _IsFavorite;
        public Boolean IsFavorite
        {
            get { return _IsFavorite; }
            set
            {
                SetValue(ref _IsFavorite, value);
            }
        }

    }


}
