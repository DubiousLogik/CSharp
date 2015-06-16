using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageElements
{
    /* ************************************************
     * ProductComparers.cs
     * 
     * Purpose:  These classes go along with the Product classes that implement the same logic via various
     *   C# language syntax.
     * 
     * Goal:  Learn specific language elements to deepen my knowledge of the C# language.  Use this knowledge in 
     *   future coding exercises - e.g. know when to use generics, delegates or predicates.
     *   
     * Author:  Robbie Devine, 15 Jun 2015  
     * ************************************************
    */
    class ProductComparers
    {
    }

    public class ProductNameComparerC1 : IComparer
    {
        public int Compare(object x, object y)
        {
            ProductC1 first = (ProductC1)x;
            ProductC1 second = (ProductC1)y;
            return first.Name.CompareTo(second.Name);
        }
    }

    public class ProductNameComparerC2 : IComparer<ProductC2>
    {
        public int Compare(ProductC2 x, ProductC2 y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }

    public class ProductPriceComparerC2 : IComparer<ProductC2>
    {
        public int Compare(ProductC2 x, ProductC2 y)
        {
            return x.Price.CompareTo(y.Price);
        }
    }
}
