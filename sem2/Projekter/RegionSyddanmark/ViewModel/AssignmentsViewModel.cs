using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegionSyd.Model;
using RegionSyd.DataAccess;
using RegionSyd.Utilities;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace RegionSyd.ViewModel
{
    class AssignmentsViewModel : INotifyPropertyChanged
    {
        private AssignmentRepository assignmentRepo = new();
        private AssignmentComboRepository assignmentComboRepo = new();
        private List<AssignmentViewModel> selectedAssignments;
        public ObservableCollection<AssignmentViewModel> Assignments { get; private set; }
        public ObservableCollection<AssignmentComboViewModel> AssignmentCombos { get; private set; }
        public AssignmentComboViewModel SelectedCombo { get; set; }
        public RelayCommand AddComboCommand { get; }
        public RelayCommandT<AssignmentComboViewModel> RemoveComboCommand { get; }

        public AssignmentsViewModel()
        {
            AddComboCommand = new RelayCommand(AddCombo);
            RemoveComboCommand = new RelayCommandT<AssignmentComboViewModel>(RemoveCombo);
            Assignments = new();
            AssignmentCombos = new();
            selectedAssignments = new();
            foreach (Assignment assignment in assignmentRepo.Assignments)
            {
                AssignmentViewModel assignmentViewModel = new AssignmentViewModel(assignment);
                Assignments.Add(assignmentViewModel);
            }
        }

        public void AddCombo()
        {
            foreach (AssignmentViewModel assignment in Assignments)
                if (assignment.IsSelected) selectedAssignments.Add(assignment);
            if (selectedAssignments.Count > 0) 
            {
                List<Assignment> selectedAssignmentsAsAssignments = new List<Assignment>();
                foreach (AssignmentViewModel assignment in selectedAssignments)
                {
                    assignmentRepo.Remove(assignment.Model);
                    Assignments.Remove(assignment);
                    selectedAssignmentsAsAssignments.Add(assignment.Model);
                }
                AssignmentCombo combo = new AssignmentCombo(selectedAssignmentsAsAssignments);
                assignmentComboRepo.Add(combo);
                AssignmentComboViewModel comboViewModel = new AssignmentComboViewModel(combo);
                AssignmentCombos.Add(comboViewModel);
            }
            selectedAssignments.Clear();
        }

        public void RemoveCombo(object parameter)
        {
            if (parameter is AssignmentComboViewModel combo)
            {
                AssignmentCombos.Remove(combo);
                assignmentComboRepo.Remove(combo.Model);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}