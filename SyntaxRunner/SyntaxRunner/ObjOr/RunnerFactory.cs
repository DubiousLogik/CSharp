using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SyntaxRunner.Lists;
using SyntaxRunner.Interfaces;
using SyntaxRunner.Performance;
using SyntaxRunner.String;

namespace SyntaxRunner.ObjOr
{
    public static class RunnerFactory
    {
        public static IExampleRunner GetExampleRunner(string name)
        {
            switch (name)
            {
                case "list":
                    return new ListExamples();
                case "oo":
                    return new OoExamples();
                case "perf":
                    return new PerfExamples();
                case "string":
                    return new StringExamples();
                default:
                    return null;
            };
        }
    }
}
