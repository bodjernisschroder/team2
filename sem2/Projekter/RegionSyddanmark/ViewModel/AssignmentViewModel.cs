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
    class AssignmentViewModel : INotifyPropertyChanged
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

        public Region Region
        {
            get { return Model.Region; }
            set
            {
                Model.Region = value;
                OnPropertyChanged(nameof(Region));
            }
        }

        public int RegionalID
        {
            get { return Model.RegionalID; }
            set
            {
                Model.RegionalID = value;
                OnPropertyChanged(nameof(RegionalID));
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

        //public DateTime ServiceGoal
        //{
        //    get { return Model.ServiceGoal; }
        //    set
        //    {
        //        Model.ServiceGoal = value;
        //        OnPropertyChanged(nameof(ServiceGoal));
        //    }
        //}

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
