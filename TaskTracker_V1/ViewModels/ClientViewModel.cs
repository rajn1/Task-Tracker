using TaskTracker_V1.Models;

// https://medium.com/swlh/xamarin-forms-mvvm-how-to-work-with-sqlite-db-c-xaml-26fcae303edd
namespace TaskTracker_V1.ViewModels
{
    // Provides all needed details to access a client
    // By extending the BaseViewModel, we can implement INotifyPropertyChanged for all clients, allowing the VewModel (VM) to be notified of changes
    public class ClientViewModel : BaseViewModel
    {
        public int ID { get; set; }

        public ClientViewModel()
        {
        }

        public ClientViewModel(Client Client)
        {
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

        // Display a star for the clients marked as Favorites
        public ImageSource ProfileImage
        {
            get
            {
                if (IsFavorite)
                {
                    return ImageSource.FromResource("TaskTracker_V1.Assets.Images.star.png");
                }
                return ImageSource.FromResource("TaskTracker_V1.Assets.Images.business.png");
            }
        }
    }
}