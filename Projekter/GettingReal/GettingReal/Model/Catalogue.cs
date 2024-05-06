using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal
{
    public static class Catalogue
    {
        public static Dictionary<string, List<string>> CategorizedProducts { get; private set; } = new Dictionary<string, List<string>>();

        public static void AddProductToCategory(string category, string product)
        {
            if (CategorizedProducts.ContainsKey(category))
            {
                CategorizedProducts[category].Add(product);
                return;
            }
            List<string> productList = new List<string> { product };
            CategorizedProducts.Add(category, productList);
        }
    }
}
