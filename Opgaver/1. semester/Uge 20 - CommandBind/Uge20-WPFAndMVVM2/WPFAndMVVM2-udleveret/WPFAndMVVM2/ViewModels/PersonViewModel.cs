using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFAndMVVM2.Models;

namespace WPFAndMVVM2.ViewModels
{
    public class PersonViewModel
    {
        private Person person;

        public string FirstName 
        { 
            get { return person.FirstName; }  
            set {  person.FirstName = value; }
        }    
       
        public string LastName 
        { 
            get { return person.LastName; }  
            set { person.LastName = value; }
        }
        
        public int Age 
        {
            get { return person.Age; } 
            set { person.Age = value; }
        }
        
        public string Phone 
        { 
            get { return person.Phone; } 
            set { person.Phone = value; }
        }
        
        public int Id { get { return person.Id; } }


        public void DeletePerson(PersonRepository personRepo)
        {
            personRepo.Remove(Id);
        }
        

        public PersonViewModel (Person person)
        {
            this.person = person;
        }

    }
}
