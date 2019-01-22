using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MovingData.Json;
using MovingData.ProductCatalog;
using MovingData.OrderManagement;

namespace MovingData
{
    class Program
    {
        static void Main(string[] args)
        {
            var catalogManager = new CatalogManager();
            var catalog = catalogManager.Load();

            var order = OrderSampleGenerator.CreateOrder(24, catalog);

            JsonRunner.Run(order);
            //XmlRunner.Run(order);
            //ProtoBufRunner.Run(order);
            //CsvRunner.Run(order);

            Console.ReadLine();
        }
    }
}
