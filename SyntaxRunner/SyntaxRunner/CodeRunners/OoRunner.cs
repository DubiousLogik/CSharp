﻿using System;
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
        private IExampleRunner runner;

        public OoRunner()
        {
            this.runner = new OoExamples();
        }

        public void Run()
        {
            this.runner.RunExamples();
        }
    }
}