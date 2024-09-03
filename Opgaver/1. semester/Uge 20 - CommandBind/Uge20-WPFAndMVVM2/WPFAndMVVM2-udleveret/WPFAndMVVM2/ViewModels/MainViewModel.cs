using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using WPFAndMVVM2.Models;

namespace WPFAndMVVM2.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private PersonRepository personRepo = new PersonRepository();

        private PersonViewModel _selectedPerson;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public PersonViewModel SelectedPerson 
        { 
            get { return _selectedPerson; } 
            
            set 
            {
                _selectedPerson = value;
                OnPropertyChanged(nameof(SelectedPerson)); //("SelectedPerson")
                      
            }
        
        }

        // Implement the rest of this MainViewModel class below to 
        // establish the foundation for data binding !
        public ObservableCollection<PersonViewModel> PersonsVM { get ; set; }

        public MainViewModel()
        {
            // Opretter en instans af person listen fra PersonRepo
            List<Person> persons = personRepo.GetAll();

            PersonsVM = new ObservableCollection<PersonViewModel>();

            foreach (Person person in persons)
            {
                PersonViewModel personViewModel = new PersonViewModel(person);
                PersonsVM.Add(personViewModel);
            }

        }//👈😎👈
        
        //PersonsVM.Add(new Person {FirstName = "Specify FirstName", LastName = "Specify LastName, Age = 0, Phone = "Specify Phone"})
        public void AddDefaultPerson()
        {
            Person addPerson = personRepo.Add("Specify FirstName", "Specify LastName", 0, "Specify Phone");
            PersonViewModel newPersonViewModel = new PersonViewModel(addPerson);
            PersonsVM.Add(newPersonViewModel);
            SelectedPerson = newPersonViewModel;
            
            
            //Bo's løsning (længe leve var):
            //var addPerson = personRepo.Add("Specify FirstName", "Specify LastName", 0, "Specify Phone");
            //var newPersonViewModel = new PersonViewModel(addPerson);
            //PersonsVM.Add(newPersonViewModel);
            //SelectedPerson = PersonsVM[PersonsVM.Count - 1];
        }

        public void DeleteSelectedPerson()
        {
            SelectedPerson.DeletePerson(personRepo);
            PersonsVM.Remove(SelectedPerson);
        }
        public ICommand NewCmd { get; set; } = new NewCommand();
        public ICommand DeleteCmd { get; set; } = new DeleteCommand();






    }
}
