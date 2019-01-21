using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SyntaxRunner.Interfaces;

namespace SyntaxRunner.CodeRunners
{
    public class ExampleRunner : IRunnable
    {
        private IExampleRunner exampleRunner;

        public ExampleRunner(string runnerName)
        {
            this.exampleRunner = RunnerFactory.GetExampleRunner(runnerName);
        }

        public void Run()
        {
            this.exampleRunner.RunExamples();
        }
    }
}
