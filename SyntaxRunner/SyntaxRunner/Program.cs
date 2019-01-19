using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SyntaxRunner.CodeRunners;
using SyntaxRunner.Interfaces;

namespace SyntaxRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var runList = new List<IRunnable>()
            {
                new ListRunner(),
                new OoRunner(),
                new PerfRunner(),
                new StringRunner()
            };

            ExecuteRunList(runList);

            Console.ReadLine();
        }

        private static void ExecuteRunList(List<IRunnable> list)
        {
            foreach (var item in list)
            {
                item.Run();
            }
        }
    }
}
