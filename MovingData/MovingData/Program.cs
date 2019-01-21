using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MovingData.Json;

namespace MovingData
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonRunner.Run();

            Console.ReadLine();
        }
    }
}
