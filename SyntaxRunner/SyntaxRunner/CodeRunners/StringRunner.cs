using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SyntaxRunner.Interfaces;
using SyntaxRunner.String;

namespace SyntaxRunner.CodeRunners
{
    public class StringRunner : IRunnable
    {
        private IExampleRunner runner;

        public StringRunner()
        {
            this.runner = new StringExamples();
        }
        public void Run()
        {
            this.runner.RunExamples();
        }
    }
}
