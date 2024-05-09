using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GettingReal.View;

namespace GettingReal
{
    public class DataHandler
    {
        public string DataFileName { get; }

        public DataHandler() { }

        public DataHandler(string dataFileName)
        {
            DataFileName = dataFileName;
        }

        public void LoadCatalogue()
        {
            if (!File.Exists(DataFileName))
            {
                throw new ArgumentException("File does not exist.", nameof(DataFileName));
            }

            using (StreamReader reader = new StreamReader(DataFileName))
            {
                string line;
                List<string> catalogueItem = new List<string>();
                while ((line = reader.ReadLine()) != null)
                {
                    catalogueItem = line.Split(",").ToList();
                    Catalogue.AddProductToCategory(catalogueItem[0], catalogueItem[1]);
                }
            }
        }
        public void LoadBudgetFromFile(string filePath, BudgetController budgetController)
        {
            budgetController.ResetBudget();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(',');
                    budgetController.AddProduct(parts[0], int.Parse(parts[1]));
                }
            }
            budgetController.UpdateSum();
        }

        public static void SaveBudgetToFile(string filePath, List<Product> products)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var product in products)
                {
                    writer.WriteLine($"{product.Name},{product.TimeEstimate}");
                }
            }
        }

    }

}
