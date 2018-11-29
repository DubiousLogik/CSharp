using Patterns.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Bridge
{
    public static class BridgePatternRunner
    {
        public static void Run()
        {
            // These objects come from external API calls
            var goldenGate = new SuspensionBridge("GoldenGate", 2, new string[2] { "cars", "pedestrians" });
            var stateRoad520 = new FloatingBridge("SR520", 3, new string[3] { "cars", "bicycles", "pedestrians"});
            var interstate90 = new FloatingBridge("Interstate90", 3, new string[4] { "cars", "bicycles", "pedestrians", "trains" });

            // These objects conform to your own business objects that other systems expect
            var bridge1 = new BridgeAdapter(goldenGate);
            var bridge2 = new BridgeAdapter(stateRoad520);
            var bridge3 = new BridgeAdapter(interstate90);

            // This simulates passing the object downstream to another component that speaks IAbstractBridge methods
            OutputHelper.OutputBridgeDataToConsole(bridge1);
            OutputHelper.OutputBridgeDataToConsole(bridge2);
            OutputHelper.OutputBridgeDataToConsole(bridge3);
        }
    }
}
