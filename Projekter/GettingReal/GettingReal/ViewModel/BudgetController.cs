using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal
{
    public class BudgetController
    {
        // Har svært ved at gennemskue hvilken parameter, den skal have under budget
        // Måske returneres her til UI
        public Budget CreateBudget()
        {
            Budget budget = new Budget();
        }
        
        // Kan vi access dem uden at returnere dem?
        public void CreateBudgetSuggestions(Budget budget) 
        {
            Budget highBudget = new Budget(budget, PriceLevel.High);
            Budget medBudget = new Budget(budget, PriceLevel.Medium);
            Budget lowBudget = new Budget(budget, PriceLevel.Low);
        }

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

        public void AddProduct(Budget budget, Product product) 
        { 
            budget.Products.Add(product);
            UpdateSum(budget);
        }

        public void RemoveProduct (Budget budget, Product product)
        {
            budget.Products.Remove(product);
            UpdateSum(budget);
        }
        
        public void ChangePriceLevel(Budget budget, PriceLevel priceLevel)
        {
            budget.PriceLevel = priceLevel;
            ProductController productController = new ProductController();
            foreach (Product product in budget.Products)
            {
                productController.ChangePriceLevel(product, budget.PriceLevel);
            }
        }

        public void SelectDiscount(Budget budget, double discountPercentage)
        {
            budget.CalculateDiscount(discountPercentage);
        }

        public void UpdateSum(Budget budget)
        {
            budget.CalculateSum();
        }

        public void ResetBudget(Budget budget)
        {
            budget.Products.Clear();
            budget.PriceLevel = PriceLevel.High;
            budget.DiscountPercentage = 0;
            UpdateSum(budget);
        }
    }
}
