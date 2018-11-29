using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Bridge
{
    public class BridgeAdapter : IAbstractBridge
    {
        private IBridgeDefinition bridge;

        public BridgeAdapter(IBridgeDefinition bridge)
        {
            this.bridge = bridge;
        }

        public string BridgeName()
        {
            return this.bridge.GetBridgeName();
        }

        public string BridgeCategory()
        {
            return this.bridge.GetBridgeType();
        }

        public int Distance()
        {
            return this.bridge.GetLengthInMiles();
        }

        public string[] SupportedTrafficTypes()
        {
            return this.bridge.GetSupportedTransitTypes();
        }
    }
}
