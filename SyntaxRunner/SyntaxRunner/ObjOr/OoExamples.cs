using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SyntaxRunner.Interfaces;

namespace SyntaxRunner.ObjOr
{
    public class OoExamples : IExampleRunner
    {
        public void RunExamples()
        {
            var m = new Mutability();
            m.RunMutabilityExamples();

            var n = new NullChecking();
            n.TestForNulls();

            n.ConditionalNulls();

            ObjectProperties.StringObjectsComparison();
            ObjectProperties.CompareSizes();
        }
    }
}
