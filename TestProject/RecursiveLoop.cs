using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    class RecursiveLoop
    {
        static void Main(string[] args)
        {
            var sampleProducts = new RecursiveLoop().GetSampleProducts();
            var productPriceGetter = new ProducetPriceGetter();
            Console.WriteLine("Expected value: 63");
            Console.WriteLine("Actual value: {0:C}", productPriceGetter.GetTotal(sampleProducts[0]));

            sampleProducts = new RecursiveLoop().GetSampleProducts();
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("Expected value: 17");
            Console.WriteLine("Actual value: {0:C}", productPriceGetter.GetTotal(sampleProducts[0], (product) => string.Equals(product.Category, "men")));
            Console.ReadLine();
        }

        public List<Product> GetSampleProducts()
        {
            var product1 = new Product()
            {
                Price = 10,
                ChildItems = new List<Product>()
                {
                    new Product()
                    {
                        Price = 5, ChildItems = new List<Product>()
                        {
                            new Product() {Price = 2},
                            new Product() {Price = 3, Category = "men"},
                            new Product()
                            {
                                Price = 6, ChildItems = new List<Product>()
                                {
                                    new Product() {Price = 7, Category = "men"}
                                }
                            }
                        }
                    },
                     new Product()
                    {
                        Price = 6, ChildItems = new List<Product>()
                        {
                            new Product() {Price = 5},
                            new Product() {Price = 3},
                            new Product()
                            {
                                Category = "men",
                                Price = 7, ChildItems = new List<Product>()
                                {
                                    new Product() {Price = 9}
                                }
                            }
                        }
                    }
                }
            };

            return new List<Product>()
            {
                product1
            };
        } 

        public class ProducetPriceGetter
        {
            public decimal GetTotal(Product product)
            {
                if (product.ChildItems != null)
                {
                    foreach (var item in product.ChildItems)
                    {
                        product.Total += this.GetTotal(item);
                    }
                }

                product.Total += product.Price;
                return product.Total;
            }

            public decimal GetTotal(Product product, Func<Product, bool> meetConditionFunc)
            {
                if (product.ChildItems != null)
                {
                    foreach (var item in product.ChildItems)
                    {
                        product.Total += this.GetTotal(item);
                    }
                }

                if (meetConditionFunc(product))
                {
                    product.Total += product.Price;
                }
                
                return product.Total;
            }
        }

        public class Product
        {
            public string Category { get; set; }
            public decimal Total { get; set; }
            public decimal Price { get; set; }
            public List<Product> ChildItems { get; set; }
        }
    }
}
