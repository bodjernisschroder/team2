using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal
{
    public static class Catalogue
    {
        public static Dictionary<string, List<string>> CategorizedProducts { get; set; } = new Dictionary<string, List<string>>();


        // Er For-loopet ikke lidt redudant her? Index i bliver ikke brugt nogen steder
        public static void AddProductToCategory(string category, string product)
        {
            for (int i = 0; i < CategorizedProducts.Keys.Count; i++)
            {
                if (CategorizedProducts.ContainsKey(category))
                {
                    CategorizedProducts[category].Add(product);
                    return;
                }
            }
            List<string> productList = new List<string> { product };
            CategorizedProducts.Add(category, productList);
        }
    }
}
