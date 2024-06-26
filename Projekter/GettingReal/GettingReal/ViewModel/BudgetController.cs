﻿using System.ComponentModel;

namespace GettingReal
{
    public class BudgetController
    {
        public static Budget Budget { get; private set; }

        public double DiscountPercentage
        {
            get { return Budget.DiscountPercentage; }
            set
            {
                if (Budget.DiscountPercentage != value)
                {
                    Budget.DiscountPercentage = value;
                    OnPropertyChanged("DiscountPercentage");
                }
            }
        }

        public static double Sum
        { 
            get { return Budget.Sum; }              
        }

        public static List<Product> Products
        {
            get { return Budget.Products; }
        }

        public void CreateBudget()
        {
            Budget = new Budget();
        }

        public void AddProduct(string name, int timeEstimate) 
        {
            ProductController productController = new ProductController();
            Product product = productController.CreateProduct(name, timeEstimate, Budget.PriceLevel);
            Budget.Products.Add(product);
            UpdateSum();
        }

        public void RemoveProduct (Product product)
        {
            Budget.Products.Remove(product);
            UpdateSum();
        }
        
        public void ChangePriceLevel(PriceLevel priceLevel, bool customPricesLocked)
        {
            Budget.PriceLevel = priceLevel;
            ProductController productController = new ProductController();
            foreach (Product product in Budget.Products)
            {
                if (customPricesLocked == true)
                {
                    if (product.PriceLevel != PriceLevel.Custom) productController.ChangePriceLevel(product, Budget.PriceLevel);
                }
                else productController.ChangePriceLevel(product, Budget.PriceLevel);
            }
            UpdateSum();
        }

        public void ApplyDiscount(int discountPercentage)
        {
            Budget.CalculateDiscount(discountPercentage);
            UpdateSum();
        }

        public void UpdateSum()
        {
            Budget.CalculateSum();
        }

        public void ResetBudget()
        {
            Budget.Products.Clear();
            Budget.PriceLevel = PriceLevel.High;
            Budget.DiscountPercentage = 0;
            UpdateSum();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}