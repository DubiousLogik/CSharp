using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SyntaxRunner.CodeRunners;

namespace SyntaxRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            PerfRunner.Run();

            Console.ReadLine();
        }
    }
}
