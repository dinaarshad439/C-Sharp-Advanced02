using System.Collections;
using System.Reflection.Emit;

namespace C_Advanced02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> catalog = new()
            {
                new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 1200, Stock = 10 },
                new Product { Id = 2, Name = "Phone", Category = "Electronics", Price = 800, Stock = 25 },
                new Product { Id = 3, Name = "T-Shirt", Category = "Clothing", Price = 30, Stock = 100 },
                new Product { Id = 4, Name = "Jeans", Category = "Clothing", Price = 60, Stock = 50 },
                new Product { Id = 5, Name = "Chocolate", Category = "Food", Price = 5, Stock = 200 },
                new Product { Id = 6, Name = "Coffee Beans", Category = "Food", Price = 15, Stock = 80 },
                new Product { Id = 7, Name = "C# Book", Category = "Books", Price = 45, Stock = 30 },
                new Product { Id = 8, Name = "Novel", Category = "Books", Price = 20, Stock = 60 },
                new Product { Id = 9, Name = "Headphones", Category = "Electronics", Price = 150, Stock = 40 },
                new Product { Id = 10, Name = "Jacket", Category = "Clothing", Price = 120, Stock = 15 }
            };


            #region Task1 Smart Product Search

            Console.WriteLine("----------electronics---------------\n");
            var electronic = SearchProducts(catalog, p => p.Category == "Electronics");
            foreach (var product in electronic)
            {
                Console.WriteLine($"{product.Name}- ${product.Price} (Stock:{product.Stock})");
            }

            Console.WriteLine("\n----------under 50s---------------\n");
            var ProductUnder50 = SearchProducts(catalog, p => p.Price < 50);
            foreach (var product in ProductUnder50)
            {
                Console.WriteLine($"{product.Name}- ${product.Price} (Stock:{product.Stock})");
            }

            Console.WriteLine("\n----------In Stock---------------\n");
            var InStock = SearchProducts(catalog, p => p.Stock > 0);
            foreach (var product in InStock)
            {
                Console.WriteLine($"{product.Name}- ${product.Price} (Stock:{product.Stock})");
            }

            Console.WriteLine("\n----------Clothing Under 100---------------\n");
            var ClothingUnder100 = SearchProducts(catalog, p => p.Category == "Clothing" && p.Price < 100);
            foreach (var product in ClothingUnder100)
            {
                Console.WriteLine($"{product.Name}- ${product.Price} (Stock:{product.Stock})");
            }

            #endregion

            #region Task3 Custom Report Generator

            #region Task3.1 Print Reports

            Console.WriteLine("\n----------Short Report---------------\n");
            var ShortReport = PrintReport(catalog, p => Console.WriteLine($"{p.Name} - ${p.Price}"));

            Console.WriteLine("\n----------Detailed Report---------------\n");
            var DetailedReport = PrintReport(catalog, p => Console.WriteLine($"[{p.Category}] {p.Name}| Price: ${p.Price}| Stock:{p.Stock}"));

            #endregion


            #endregion




        }

        /// <summary>
        /// Delegate Used: Func<Product, bool>
        /// Why: Func takes input parameters and returns a value. Here it takes a Product and returns 
        /// a boolean (true/false) condition, making it ideal for filtering and searching.
        /// </summary>
        public static List<Product> SearchProducts(List<Product> list, Func<Product, bool> filter)
        {
            List<Product> products = new List<Product>();

            foreach (Product product in list)
            {
                if (filter(product)) products.Add(product);
            }
            return products;
        }

        /// <summary>
        /// Delegate Used: Action<Product>
        /// Why: Action represents a method that takes an input and returns void. It is perfect 
        /// for performing an operation on each item (like printing reports) without returning data.
        /// </summary>
        public static List<Product> PrintReport(List<Product> list, Action<Product> action)
        {
            List<Product> products = new List<Product>();

            foreach (Product product in list)
            {
                action(product);
            }
            return products;
        }



    }
}
