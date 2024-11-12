﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Publico_Kommunikation_Project.Models;

namespace Publico_Kommunikation_Project.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        public Product Model { get; private set; }

        public ProductViewModel(Product product)
        {
            Model = product;
        }

        public int ProductId
        {
            get { return Model.ProductId; }
            set 
            { 
                Model.ProductId = value;
                OnPropertyChanged(nameof(ProductId));
            }
        }

        public string ProductName
        {
            get { return Model.ProductName; }
            set
            {
                Model.ProductName = value;
                OnPropertyChanged(nameof(ProductName));
            }
        }

        public int CategoryId
        {
            get { return Model.CategoryId; }
            set
            {
                Model.CategoryId = value;
                OnPropertyChanged(nameof(CategoryId));
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