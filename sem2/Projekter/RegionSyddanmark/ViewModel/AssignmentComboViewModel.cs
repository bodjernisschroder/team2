using RegionSyd.Model;
using System.ComponentModel;

namespace RegionSyd.ViewModel
{
    public class AssignmentComboViewModel : INotifyPropertyChanged
    {
        public AssignmentCombo Model { get; private set; }

        public int ComboId
        {
            get { return Model.ComboId; }
            set
            {
                Model.ComboId = value;
                OnPropertyChanged(nameof(ComboId));
            }
        }

        public int RegionalId1
        {
            get { return Model.RegionalId1; }
            set
            {
                Model.RegionalId1 = value;
                OnPropertyChanged(nameof(RegionalId1));
            }
        }

        public int RegionalId2
        {
            get { return Model.RegionalId2; }
            set
            {
                Model.RegionalId2 = value;
                OnPropertyChanged(nameof(RegionalId2));
            }
        }

        public int RegionalId3
        {
            get { return Model.RegionalId3; }
            set
            {
                Model.RegionalId3 = value;
                OnPropertyChanged(nameof(RegionalId3));
            }
        }

        public int RegionalId4
        {
            get { return Model.RegionalId4; }
            set
            {
                Model.RegionalId4 = value;
                OnPropertyChanged(nameof(RegionalId4));
            }
        }

        public int RegionalId5
        {
            get { return Model.RegionalId5; }
            set
            {
                Model.RegionalId5 = value;
                OnPropertyChanged(nameof(RegionalId5));
            }
        }

        public string RegionalComboString
        {
            get
            {
                if (RegionalId1 != 0 && RegionalId2 != 0 && RegionalId3 == 0) return $" {Model.RegionalId1}, {Model.RegionalId2}";
                else if (RegionalId3 != 0 && RegionalId4 == 0) return $" {Model.RegionalId1}, {Model.RegionalId2}, {Model.RegionalId3}";
                else if (RegionalId4 != 0 && RegionalId5 == 0) return $" {Model.RegionalId1}, {Model.RegionalId2}, {Model.RegionalId3}, {Model.RegionalId4}";
                else return $" {Model.RegionalId1}, {Model.RegionalId2}, {Model.RegionalId3}, {Model.RegionalId4}, {Model.RegionalId5}";
            }
        }

        public AssignmentComboViewModel(AssignmentCombo combo)
        {
            Model = combo;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
