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
        public void CreateBudgetSuggestions() 
        {

            //Budget budget = new Budget(, PriceLevel.Medium);
            //Budget budget1 = new Budget(, PriceLevel.Low);

        }

        public void SelectBudget() 
        {
            //Min tanke her er at have en array af selections eller blot give dem alle et tal, som brugeren skal vælge ud af.
            //Der findes helt klart en nemmere metode at bruge under WPF, men det er min umiddelbare tanke

            int[] userSelection = new int[3];
            userSelection[0] = 1; //budget 1;
            userSelection[1] = 2; //budget 2;
            userSelection[2] = 3; //budget 3;


        }

        public void AddProduct() 
        { 
            ProductController productController = new ProductController();
            List<Product> products = new List<Product>(); 
            Product product = new Product("", 0);
            productController.CreateProduct(product.Name, product.TimeEstimate);
            products.Add(product);
            
        }

        public void RemoveProduct ()
        {
            ProductController productController = new ProductController();
            List<Product> products = new List<Product>();
            Budget budget = new Budget();
            Product product = new Product("", 0);
            productController.CreateProduct(product.Name, product.TimeEstimate);
            products.Remove(product);
            //budget.CalculateSum(); //Budgettet skal opdateres eftersom, at produktet bliver fjernet her. 
            
        }
        
        public void ChangePriceLevel()
        {
            //priceLevelselection via en array 
            List<Product> products = new List<Product>();
            foreach (Product product in products)
            {
                
            }
          

        }

        public void SelectDiscount()
        {

        }



    }
}
