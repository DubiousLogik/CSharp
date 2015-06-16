using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageElements
{
    /* ************************************************
     * Products.cs
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
    public class Products
    {
    }

    public class ProductC1
    {
        //uses only C# 1.0 
        string _name;
        decimal _price;

        public string Name { get { return _name; } }
        public decimal Price { get { return _price; } }

        public ProductC1(string name, decimal price)
        {
            _name = name;
            _price = price;
        }

        public static ArrayList GetSampleProducts()
        {
            ArrayList productList = new ArrayList();
            productList.Add(new ProductC1("Paul Mitchell Extreme Goo", 22.99m));
            productList.Add(new ProductC1("Aquanet Permahold", 2.19m));
            productList.Add(new ProductC1("Hipster Moustache Wax", 7.99m));
            productList.Add(new ProductC1("Brylcream", 3.99m));
            productList.Add(new ProductC1("Grecian Formula, for Men", 8.99m));
            productList.Add(new ProductC1("J. Crew UberCoiff", 36.99m));

            return productList;
        }

        public override string ToString()
        {
            return String.Format("{0}: {1}", Name, Price);
        }
    }

    public class ProductC2
    {
        //adds capabilities from C# 2.0

        string _name;
        decimal _price;

        public string Name
        {
            get { return _name; }
            private set { _name = value; }  //new
        }
        public decimal Price
        {
            get { return _price; }
            private set { _price = value; }  //new
        }

        public ProductC2(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public static List<ProductC2> GetSampleProducts()  //new
        {
            List<ProductC2> productList = new List<ProductC2>();
            productList.Add(new ProductC2("Paul Mitchell Extreme Goo", 22.99m));
            productList.Add(new ProductC2("Aquanet Permahold", 2.19m));
            productList.Add(new ProductC2("Hipster Moustache Wax", 7.99m));
            productList.Add(new ProductC2("Brylcream", 3.99m));
            productList.Add(new ProductC2("Grecian Formula, for Men", 8.99m));
            productList.Add(new ProductC2("J. Crew UberCoiff", 36.99m));

            return productList;
        }

        public override string ToString()
        {
            return String.Format("{0}: {1}", Name, Price);
        }
    }

    public class ProductC3
    {
        //adds capabilities from C# 3.0

        public string Name { get; private set; }  //new
        public decimal Price { get; private set; }  //new

        public ProductC3(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
        public ProductC3() { }

        public static List<ProductC3> GetSampleProducts()
        {
            return new List<ProductC3> 
            {
                new ProductC3("Paul Mitchell Extreme Goo", 22.99m),
                new ProductC3("Aquanet Permahold", 2.19m),
                new ProductC3("Hipster Moustache Wax", 7.99m),
                new ProductC3("Brylcream", 3.99m),
                new ProductC3("Grecian Formula, for Men", 8.99m),
                new ProductC3 { Name="J. Crew UberCoiff", Price= 36.99m } //new
            };

        }

        public override string ToString()
        {
            return String.Format("{0}: {1}", Name, Price);
        }
    }
}
