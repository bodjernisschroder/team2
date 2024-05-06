using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal
{
    public class BudgetController
    {
        public static Budget Budget { get; private set; }

        // Har svært ved at gennemskue hvilken parameter, den skal have under budget
        // Måske returneres her til UI
        public void CreateBudget()
        {
            Budget = new Budget();
        }
        
        // Kan vi access dem uden at returnere dem?

        public void SelectBudget() 
        {
            //Min tanke her er at have en array af selections eller blot give dem alle et tal, som brugeren skal vælge ud af.
            //Der findes helt klart en nemmere metode at bruge under WPF, men det er min umiddelbare tanke
            //Her vil vi returnere det valgte budget (i en konsolapplikation) - Hvordan ser det ud, når vi arbejder med WPF
            int[] userSelection = new int[3];
            userSelection[0] = 1; //budget 1;
            userSelection[1] = 2; //budget 2;
            userSelection[2] = 3; //budget 3;
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
        
        public void ChangePriceLevel(PriceLevel priceLevel)
        {
            Budget.PriceLevel = priceLevel;
            ProductController productController = new ProductController();
            foreach (Product product in Budget.Products)
            {
                productController.ChangePriceLevel(product, Budget.PriceLevel);
            }
        }

        public void SelectDiscount(Budget budget, double discountPercentage)
        {
            budget.CalculateDiscount(discountPercentage);
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
