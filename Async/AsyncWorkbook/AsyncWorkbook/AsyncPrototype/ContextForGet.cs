using System;
using System.Collections.Generic;
using System.IdentityModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncWorkbook.AsyncPrototype
{
    public class ContextForGet
    {
        public string Url { get; set; }

        public string Reply { get; set; }

        public TypedAsyncResult<string> AsyncResult { get; set; }
    }
}
