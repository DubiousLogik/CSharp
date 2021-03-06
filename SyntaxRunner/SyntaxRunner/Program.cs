﻿using System;
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
            var runList = new List<string>();

            //runList.Add("list");
            runList.Add("oo");
            //runList.Add("perf");
            runList.Add("string");
            //runList.Add("datetime");
            //runList.Add("numeric");

            ExecuteRunList(runList);

            Console.ReadLine();
        }

        private static void ExecuteRunList(List<string> list)
        {
            foreach (var item in list)
            {
                var runner = new ExampleRunner(item);

                Console.WriteLine();
                Console.WriteLine($"Running {item.GetType().Name} =============================================================");
                Console.WriteLine();

                runner.Run();

                Console.WriteLine();
                Console.WriteLine($"Ending {item.GetType().Name} =============================================================");
                Console.WriteLine();
            }
        }
    }
}
