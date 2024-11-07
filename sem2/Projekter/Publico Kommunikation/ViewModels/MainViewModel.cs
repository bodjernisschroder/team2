using Template.DataAccess;
using Template.Models;
using System.Collections.ObjectModel;
using Template.Utilities;

namespace Template.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ClassTemplateRepository _classTemplateRepository;
        public ObservableCollection<ClassTemplateViewModel> ClassTemplateViewModels;
        public RelayCommand<int> GetByIdClassTemplateCommand { get; }
        public RelayCommand<ClassTemplateViewModel> AddClassTemplateCommand { get; }
        public RelayCommand<ClassTemplateViewModel> UpdateClassTemplateCommand { get; }
        public RelayCommand<ClassTemplateViewModel> DeleteClassTemplateCommand { get; }

        public MainViewModel(ClassTemplateRepository classTemplateRepository)
        {
            // Initialize collections
            _classTemplateRepository = classTemplateRepository;
            ClassTemplateViewModels = new ObservableCollection<ClassTemplateViewModel>();

            // Initialize RelayCommands
            GetByIdClassTemplateCommand = new RelayCommand<int>(GetByIdClassTemplate);
            AddClassTemplateCommand = new RelayCommand<ClassTemplateViewModel>(AddClassTemplate);
            UpdateClassTemplateCommand = new RelayCommand<ClassTemplateViewModel>(AddClassTemplate);
            DeleteClassTemplateCommand = new RelayCommand<ClassTemplateViewModel>(DeleteClassTemplate);

            // Populate ObservableCollection with values from repository
            foreach (ClassTemplate classTemplate in classTemplateRepository.GetAll())
            {
                ClassTemplateViewModel classTemplateViewModel = new ClassTemplateViewModel(classTemplate);
                ClassTemplateViewModels.Add(classTemplateViewModel);
            }
        }

        // Retrieves ClassTemplate by ID and adds to collection
        public void GetByIdClassTemplate(int classTemplateViewModelId)
        {
            if (classTemplateViewModelId > 0)
            {
                // GetById ClassTemplate and store in temporary classTemplate variable
                var classTemplate = _classTemplateRepository.GetById(classTemplateViewModelId);
                
                // Adds the found classTemplate to ClassTemplateViewModel collection
                if (classTemplate != null)
                {
                    var classTemplateViewModel = new ClassTemplateViewModel(classTemplate);

                    // Ensure ClassTemplateViewModel does not already exist in the collection
                    if (!ClassTemplateViewModels.Any(vm => vm.Model.ClassTemplateId == classTemplateViewModel.Model.ClassTemplateId))
                        ClassTemplateViewModels.Add(classTemplateViewModel);
                }
            }
        }


        // Adds ClassTemplate to collections
        public void AddClassTemplate(ClassTemplateViewModel classTemplateViewModel)
        {
            if (classTemplateViewModel != null)
            {
                // ClassTemplateViewModel is added to ClassTemplateViewModels
                ClassTemplateViewModels.Add(classTemplateViewModel);

                // ClassTemplate is added to classTemplateRepository
                _classTemplateRepository.Add(classTemplateViewModel.Model);
            }
        }

        // Updates Repository
        public void UpdateClassTemplate(ClassTemplateViewModel classTemplateViewModel)
        {
            _classTemplateRepository.Update(classTemplateViewModel.Model);
        }

        // Deletes ClassTemplate from collections
        public void DeleteClassTemplate(ClassTemplateViewModel classTemplateViewModel)
        {
            if (classTemplateViewModel != null)
            {
                // ClassTemplateViewModel is removed from ClassTemplateViewModels
                ClassTemplateViewModels.Remove(classTemplateViewModel);

                // ClassTemplate is deleted from classTemplateRepository
                _classTemplateRepository.Delete(classTemplateViewModel.Model.ClassTemplateId);
            }
        }
    }
}