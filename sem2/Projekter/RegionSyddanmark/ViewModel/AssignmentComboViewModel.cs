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
    class AssignmentComboViewModel : INotifyPropertyChanged
    {
        public AssignmentCombo Model { get; private set; }

        public int ID
        {
            get { return Model.ID; }
            set
            {
                Model.ID = value;
                OnPropertyChanged(nameof(ID));
            }
        }

        public List<Assignment> Assignments
        {
            get { return Model.Assignments; }
            set
            {
                Model.Assignments = value;
                OnPropertyChanged(nameof(ID));
            }
        }

        public string AssignmentIds
        {
            get
            {
                return string.Join(", ", Assignments.Select(a => a.RegionalID));
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
