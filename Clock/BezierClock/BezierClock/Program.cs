using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BezierClock
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            bool useUtc = false;

            if (args?.Length == 1)
            {
                if (args[0]?.ToLower() == "utc")
                {
                    useUtc = true;
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new AnalogClock());
            Application.Run(new BezierClock(useUtc));
        }
    }
}
