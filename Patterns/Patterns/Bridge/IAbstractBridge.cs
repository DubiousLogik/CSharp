using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Bridge
{
    public interface IAbstractBridge
    {
        string BridgeName();

        string[] SupportedTrafficTypes();

        int Distance();

        string BridgeCategory();
    }
}
