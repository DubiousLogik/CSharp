using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Bridge
{
    public class SuspensionBridge : IBridgeDefinition
    {
        private string name;
        private int length;
        private string[] transitTypes;
        private string bridgeType = "SuspensionBridge";

        public SuspensionBridge(string name, int length, string[] transitTypes)
        {
            this.name = name;
            this.length = length;
            this.transitTypes = transitTypes;
        }

        public string GetBridgeName()
        {
            return this.name;
        }

        public int GetLengthInMiles()
        {
            return this.length;
        }

        public string[] GetSupportedTransitTypes()
        {
            return this.transitTypes;
        }

        string IBridgeDefinition.GetBridgeType()
        {
            return this.bridgeType;
        }
    }
}
