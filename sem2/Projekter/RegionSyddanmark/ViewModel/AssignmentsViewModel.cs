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
    public class AssignmentsViewModel : INotifyPropertyChanged
    {
        private AssignmentRepository assignmentRepo;
        private AssignmentComboRepository assignmentComboRepo;
        private RegionRepository regionRepo;
        private TypeRepository typeRepo;
        private List<AssignmentViewModel> selectedAssignments;
        public ObservableCollection<AssignmentViewModel> Assignments { get; private set; }
        public ObservableCollection<AssignmentComboViewModel> AssignmentCombos { get; private set; }
        public AssignmentComboViewModel SelectedCombo { get; set; }
        public RelayCommand AddComboCommand { get; }
        public RelayCommandT<AssignmentComboViewModel> RemoveComboCommand { get; }
        public RelayCommandT<AssignmentViewModel> RemoveAssignmentCommand { get; }

        public AssignmentsViewModel(string connectionString)
        {
            AddComboCommand = new RelayCommand(AddCombo);
            RemoveComboCommand = new RelayCommandT<AssignmentComboViewModel>(RemoveCombo);
            RemoveAssignmentCommand = new RelayCommandT<AssignmentViewModel>(RemoveAssignment);
            assignmentRepo = new AssignmentRepository(connectionString);
            assignmentComboRepo = new AssignmentComboRepository(connectionString);
            regionRepo = new RegionRepository(connectionString);
            typeRepo = new TypeRepository(connectionString);
            Assignments = new ObservableCollection<AssignmentViewModel>();
            AssignmentCombos = new ObservableCollection<AssignmentComboViewModel>();
            selectedAssignments = new();
            foreach (Assignment assignment in assignmentRepo.GetAll())
            {
                AssignmentViewModel assignmentViewModel = new AssignmentViewModel(assignment);
                Assignments.Add(assignmentViewModel);
            }
            foreach (AssignmentCombo combo in assignmentComboRepo.GetAll())
            {
                AssignmentComboViewModel assignmentComboViewModel = new AssignmentComboViewModel(combo);
                AssignmentCombos.Add(assignmentComboViewModel);
            }
        }
        public void RemoveAssignment(object parameter)
        {
            if (parameter is AssignmentViewModel assignment)
            {
                Assignments.Remove(assignment);
                assignmentRepo.Delete(assignment.Model.RegionalId);
            }
        }

        public void AddCombo()
        {
            foreach (AssignmentViewModel assignment in Assignments)
                if (assignment.IsSelected) selectedAssignments.Add(assignment);
            if (selectedAssignments.Count > 0) 
            {
                AssignmentCombo combo = new AssignmentCombo();
                assignmentComboRepo.Add(combo);
                foreach (AssignmentViewModel assignment in selectedAssignments)
                {
                    assignment.ComboId = combo.ComboId;
                    // assignmentRepo.Update(assignment.Model);
                }

                // List<Assignment> selectedAssignmentsAsAssignments = new List<Assignment>();
                // foreach (AssignmentViewModel assignment in selectedAssignments)
                // {
                //     assignmentRepo.Delete(assignment.Model.RegionalId);
                //     Assignments.Remove(assignment);
                //     selectedAssignmentsAsAssignments.Add(assignment.Model);
                // }
                // AssignmentCombo combo = new AssignmentCombo(selectedAssignmentsAsAssignments);
                // assignmentComboRepo.Add(combo);
                // AssignmentComboViewModel comboViewModel = new AssignmentComboViewModel(combo);
                // AssignmentCombos.Add(comboViewModel);
            }
            selectedAssignments.Clear();
        }

        public void RemoveCombo(object parameter)
        {
            if (parameter is AssignmentComboViewModel combo)
            {
                AssignmentCombos.Remove(combo);
                assignmentComboRepo.Delete(combo.Model.ComboId);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}