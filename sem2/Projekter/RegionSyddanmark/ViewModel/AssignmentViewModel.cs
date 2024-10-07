using RegionSyd.Model;
using System.ComponentModel;
using Type = RegionSyd.Model.Type;

namespace RegionSyd.ViewModel
{
    public class AssignmentViewModel : INotifyPropertyChanged
    {
        public Assignment Model { get; private set; }
       
        public Type TypeModel { get; private set; }

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }

        public int RegionId
        {
            get { return Model.RegionId; }
            set
            {
                Model.RegionId = value;
                OnPropertyChanged(nameof(RegionId));
            }
        }

        public int RegionalId
        {
            get { return Model.RegionalId; }
            set
            {
                Model.RegionalId = value;
                OnPropertyChanged(nameof(RegionalId));
            }
        }

        public int TypeId
        {
            get { return Model.TypeId; }
            set
            {
                Model.TypeId = value;
                OnPropertyChanged(nameof(TypeId));
            }
        }

        public int ComboId
        {
            get { return Model.ComboId; }
            set
            {
                Model.ComboId = value;
                OnPropertyChanged(nameof(ComboId));
            }
        }

        public string Description
        {
            get { return Model.Description; }
            set
            {
                Model.Description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public DateTime ScheduledDateTime
        {
            get { return Model.ScheduledDateTime; }
            set
            {
                Model.ScheduledDateTime = value;
                OnPropertyChanged(nameof(ScheduledDateTime));
            }
        }

        public string FromAddress
        {
            get { return Model.FromAddress; }
            set
            {
                Model.FromAddress = value;
                OnPropertyChanged(nameof(FromAddress));
            }
        }

        public string ToAddress
        {
            get { return Model.ToAddress; }
            set
            {
                Model.ToAddress = value;
                OnPropertyChanged(nameof(ToAddress));
            }
        }

        public string ServiceGoal
        {
            get 
            {
                if (Model.TypeId == 1) return "15 minutter";
                else return "3 timer";
            }
        }

        public AssignmentViewModel(Assignment assignment)
        {
            Model = assignment;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
