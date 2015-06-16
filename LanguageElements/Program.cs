using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageElements
{
    class Program
    {
        static void Main(string[] args)
        {
            /* ************************************************
             * Main:  I'm including this since some of the language syntax is demonstrated when using 
             *   the classes, not just in their defintions.  This is evident in the lambda and OrderBy
             *   examples down in the C# 3 (ProductC3) section.  See also:  Products, ProductComparers
             * 
             * Purpose:  This is a side-by-side set of classes where I will implement the same logic in various ways, using
             *   different elements of the C# language.  This approach is based on what I've seen in the book C# In Depth.
             * 
             * Goal:  Learn specific language elements to deepen my knowledge of the C# language.  Use this knowledge in 
             *   future coding exercises - e.g. know when to use generics, delegates or predicates.
             *   
             * Author:  Robbie Devine, 15 Jun 2015  
             * ************************************************
            */
            Console.WriteLine();

            Console.WriteLine("------------- C# 1.0 Product Listing, ProductC1: -------------");
            ArrayList products = ProductC1.GetSampleProducts();
            foreach (ProductC1 p in products)
            {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine();
            Console.WriteLine(">>sorted by Name:");
            products.Sort(new ProductNameComparerC1());
            foreach (ProductC1 p in products)
            {
                Console.WriteLine("\t" + p.ToString());
            }
            Console.WriteLine();

            Console.WriteLine("------------- C# 2.0 Product Listing, ProductC2: -------------");
            List<ProductC2> productsC2 = ProductC2.GetSampleProducts();
            foreach (ProductC2 p in productsC2)
            {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine();
            Console.WriteLine(">>sorted by Name:");
            productsC2.Sort(new ProductNameComparerC2());
            foreach (ProductC2 p in productsC2)
            {
                Console.WriteLine("\t" + p.ToString());
            }
            Console.WriteLine();
            Console.WriteLine(">>sortd by Price");
            productsC2.Sort(new ProductPriceComparerC2());
            foreach (ProductC2 p in productsC2)
            {
                Console.WriteLine("\t" + p.ToString());
            }
            Console.WriteLine();
            Console.WriteLine(">>sortd by Name, via delegate");
            productsC2.Sort(delegate(ProductC2 x, ProductC2 y)
                { return x.Name.CompareTo(y.Name); }
            );
            foreach (ProductC2 p in productsC2)
            {
                Console.WriteLine("\t" + p.ToString());
            }
            Console.WriteLine();
            
            Console.WriteLine("------------- C# 3.0 Product Listing, ProductC3: -------------");
            List<ProductC3> productsC3 = ProductC3.GetSampleProducts();
            foreach (ProductC3 p in productsC3)
            {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine();
            Console.WriteLine(">>sortd by Price, via lambda");
            productsC2.Sort((x, y) => x.Price.CompareTo(y.Price));
            foreach (ProductC2 p in productsC2)
            {
                Console.WriteLine("\t" + p.ToString());
            }
            Console.WriteLine();
            Console.WriteLine(">>sortd by Name, via lambda and OrderBy");
            foreach (ProductC2 p in productsC2.OrderBy(x => x.Name))
            {
                Console.WriteLine("\t" + p.ToString());
            }
            Console.WriteLine();

        }
    }
}
