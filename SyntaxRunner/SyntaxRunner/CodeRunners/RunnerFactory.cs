using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SyntaxRunner.DateAndTime;
using SyntaxRunner.Lists;
using SyntaxRunner.Interfaces;
using SyntaxRunner.ObjOr;
using SyntaxRunner.Performance;
using SyntaxRunner.String;
using SyntaxRunner.Numeric;

namespace SyntaxRunner.CodeRunners
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
                case "datetime":
                    return new DateTimeExamples();
                case "numeric":
                    return new NumericExamples();
                default:
                    return null;
            };
        }
    }
}
