using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SyntaxRunner.Interfaces;
using SyntaxRunner.ObjOr;

namespace SyntaxRunner.CodeRunners
{
    public class OoRunner : IRunnable
    {
        public void Run()
        {
            var m = new Mutability();
            m.RunMutabilityExamples();
        }
    }
}
