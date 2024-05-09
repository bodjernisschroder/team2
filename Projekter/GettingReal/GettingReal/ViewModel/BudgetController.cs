using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using GettingReal.View;

namespace GettingReal 
{
    public class BudgetController
    {
        public static Budget Budget { get; private set; }

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

        public void ChangePriceLevelIgnoreCustom(PriceLevel priceLevel)
        {
            Budget.PriceLevel = priceLevel;
            ProductController productController = new ProductController();
            foreach (Product product in Budget.Products)
            {
                productController.ChangePriceLevel(product, Budget.PriceLevel);
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
    }
}
