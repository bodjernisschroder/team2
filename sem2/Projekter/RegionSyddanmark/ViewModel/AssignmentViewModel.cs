using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegionSyd.Model;
using RegionSyd.DataAccess;
using RegionSyd.Utilities;
using System.ComponentModel;

namespace RegionSyd.ViewModel
{
    public class AssignmentViewModel : INotifyPropertyChanged
    {
        public Assignment Model { get; private set; }
       

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

        public RegionEnum RegionEnum
        {
            get { return Model.RegionEnum; }
            set
            {
                Model.RegionEnum = value;
                OnPropertyChanged(nameof(RegionEnum));
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

        public RegionSyd.Model.Type Type
        {
            get { return Model.Type; }
            set
            {
                Model.Type = value;
                OnPropertyChanged(nameof(Type));
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

        public String ServiceGoal
        {
            get { return Model.Type.ServiceGoal; }
            set
            {
                Model.Type.ServiceGoal = value;
                OnPropertyChanged(nameof(ServiceGoal));
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
