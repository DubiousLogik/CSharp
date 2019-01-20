using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SyntaxRunner.Interfaces;

namespace SyntaxRunner.String
{
    public class StringExamples : IExampleRunner
    {
        public void RunExamples()
        {
            RunParsing();
        }

        public static void RunParsing()
        {
            string url = "http://somedomain.org/firstFolder/secondFolder/lastFolder";

            var sp = new StringParser();

            Console.WriteLine($"Last token in {url} is {sp.GetLastElement(url, '/')}");
        }
    }
}
