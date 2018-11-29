using Patterns.Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Utilities
{
    public static class OutputHelper
    {
        public static void OutputBridgeDataToConsole(IAbstractBridge bridge)
        {
            Console.WriteLine($"Name     : {bridge.BridgeName()}");
            Console.WriteLine($"Category : {bridge.BridgeCategory()}");
            Console.WriteLine($"Distance : {bridge.Distance()} miles");
            Console.WriteLine($"Traffic  : {string.Join(", ", bridge.SupportedTrafficTypes())}");
            Console.WriteLine();
        }
    }
}
