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

        private void AddCombo()
        {
            var selectedAssignments = Assignments.Where(a => a.IsSelected).ToList();

            if (selectedAssignments.Count == 0)
            {
                return;
            }

            var combo = new AssignmentCombo();

            if (selectedAssignments.Count >= 1)
                combo.RegionalId1 = selectedAssignments[0].RegionalId;
            if (selectedAssignments.Count >= 2)
                combo.RegionalId2 = selectedAssignments[1].RegionalId;
            if (selectedAssignments.Count >= 3)
                combo.RegionalId3 = selectedAssignments[2].RegionalId;
            if (selectedAssignments.Count >= 4)
                combo.RegionalId4 = selectedAssignments[3].RegionalId;
            if (selectedAssignments.Count >= 5)
                combo.RegionalId5 = selectedAssignments[4].RegionalId;

            assignmentComboRepo.Add(combo);

            var comboViewModel = new AssignmentComboViewModel(combo);
            AssignmentCombos.Add(comboViewModel);

            foreach (var assignment in selectedAssignments)
            {
                assignment.IsSelected = false;  
            }
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