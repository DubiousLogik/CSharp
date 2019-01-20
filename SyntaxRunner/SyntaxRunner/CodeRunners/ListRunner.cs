using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using SyntaxRunner.Enums;
using SyntaxRunner.Interfaces;
using SyntaxRunner.Lists;

namespace SyntaxRunner.CodeRunners
{
    public class ListRunner : IRunnable
    {
        private IExampleRunner runner;

        public ListRunner()
        {
            this.runner = new ListExamples();
        }

        public void Run()
        {
            
            this.runner.RunExamples();
        }
    }
}
