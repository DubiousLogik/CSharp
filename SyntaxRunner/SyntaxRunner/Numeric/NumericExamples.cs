using SyntaxRunner.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntaxRunner.Numeric
{
    public class NumericExamples : IExampleRunner
    {
        public void RunExamples()
        {
            this.Conversions();
        }

        private void Conversions()
        {
            int top = 45;
            int bottom = 67;

            Console.WriteLine("ToDouble");
            Console.WriteLine($"Convert each: {Convert.ToDouble(top)/Convert.ToDouble(bottom)}");
            Console.WriteLine($"Convert result: {Convert.ToDouble(top/bottom)}");

            Console.WriteLine("ToDecimal");
            Console.WriteLine($"Convert each: {Convert.ToDecimal(top) / Convert.ToDecimal(bottom)}");
            Console.WriteLine($"Convert result: {Convert.ToDecimal(top / bottom)}");
        }
    }
}
