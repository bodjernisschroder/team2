using System;
using System.ComponentModel;
using System.Diagnostics.Metrics;

namespace GettingReal
{
    internal class program
    {
        private static void Main(string[] args)
        {
            Dictionary<string, List<string>> items = new Dictionary<string, List<string>>()
            {
                { "Strategi", new List<string> { "Kommunikationsstrategi", "Virksomhedsstrategi", "Marketingstrategi" } },
                { "Film", new List<string> { "Animationsfilm", "Reklamefilm" } },
            };

            List<Product> products = new List<Product>();

            ProductController controller = new ProductController();

            while (true)
            {
                if (products.Count > 0)
                {
                    for (int i = 0; i < products.Count; i++)
                    {
                        Console.WriteLine(i + " " + products[i].Name + "\n" + products[i].TimeEstimate + "\n" + products[i].PriceLevel + "\n" + products[i].Price + "\n");
                    }
                }

                Console.WriteLine("1. Tilføj ydelse");
                Console.WriteLine("2. Redigér pris");
                Console.WriteLine("3. Redigér prisniveau");
                Console.WriteLine("4. Redigér time estimat");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Vælg kategori:");
                        for (int i = 0; i < items.Keys.Count; i++)
                        {
                            Console.WriteLine(i + " " + items.Keys.ElementAt(i));
                        }
                        int index = int.Parse(Console.ReadLine());
                        string key = items.Keys.ElementAt(index);

                        Console.WriteLine("Vælg ydelse:");
                        List<string> values = items[key];
                        for (int i = 0; i < values.Count; i++)
                        {
                            Console.WriteLine(i + " " + values[i]);
                        }
                        int value = int.Parse(Console.ReadLine());
                        Console.WriteLine("Angiv timeantal");
                        int time = int.Parse(Console.ReadLine());
                        Product product = controller.CreateProduct(items[key][value], time);
                        products.Add(product);
                        break;
                    case 2:
                        Console.WriteLine("Vælg produkt, der skal redigeres");
                        int p = int.Parse(Console.ReadLine());
                        Console.WriteLine("Angiv pris");
                        int price = int.Parse(Console.ReadLine());
                        controller.MakeCustomPrice(products[p], price);
                        break;
                    case 3:
                        Console.WriteLine("Vælg produkt, der skal redigeres");
                        int pr = int.Parse(Console.ReadLine());
                        Console.WriteLine("Angiv prisniveau");
                        Console.WriteLine("1. Høj");
                        Console.WriteLine("2. Middel");
                        Console.WriteLine("3. Lav");
                        int l = int.Parse(Console.ReadLine());
                        PriceLevel priceLevel = new PriceLevel();
                        if (l == 1) priceLevel = PriceLevel.High;
                        else if (l == 2) priceLevel = PriceLevel.Medium;
                        else if (l == 3) priceLevel = PriceLevel.Low;
                        controller.ChangePriceLevel(products[pr], priceLevel);
                        break;
                    case 4:
                        Console.WriteLine("Vælg produkt, der skal redigeres");
                        int prod = int.Parse(Console.ReadLine());
                        Console.WriteLine("Angiv timeantal");
                        int t = int.Parse(Console.ReadLine());
                        controller.ChangeTimeEstimate(products[prod], t);
                        break;
                    default:
                        break;
                }

                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}