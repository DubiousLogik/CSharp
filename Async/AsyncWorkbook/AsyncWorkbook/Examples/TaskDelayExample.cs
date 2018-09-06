using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncWorkbook.Examples
{
    public class TaskDelayExample
    {
        public void DelayWithTaskWait(int millis)
        {
            var t = Task.Run(async delegate
            {
                await Task.Delay(TimeSpan.FromMilliseconds(millis));
                return 42;
            });
            t.Wait();

            Console.WriteLine($"Task t Status: {t.Status}, Result: {t.Result}");
        }

        public async Task DelayWithTaskDelay(int millis)
        {
            await Task.Delay(millis);
        }
    }
}
