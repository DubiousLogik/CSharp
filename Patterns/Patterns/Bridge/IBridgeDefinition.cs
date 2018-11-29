using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Bridge
{
    public interface IBridgeDefinition
    {
        string GetBridgeName();
        string GetBridgeType();
        int GetLengthInMiles();
        string[] GetSupportedTransitTypes();
    }
}
