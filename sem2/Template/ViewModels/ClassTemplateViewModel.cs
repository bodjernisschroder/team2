using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Models;

namespace Template.ViewModels
{
    public class ClassTemplateViewModel : BaseViewModel
    {
        public ClassTemplate Model { get; private set; }

        public ClassTemplateViewModel(ClassTemplate classTemplate)
        {
            Model = classTemplate;
        }

        public int ClassTemplateId
        {
            get { return Model.ClassTemplateId; }
            set 
            { 
                Model.ClassTemplateId = value;
                OnPropertyChanged(nameof(ClassTemplateId));
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

        public int RelatedId
        {
            get { return Model.RelatedId; }
            set
            {
                Model.RelatedId = value;
                OnPropertyChanged(nameof(RelatedId));
            }
        }

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
        
       
    }
}
