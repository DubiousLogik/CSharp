using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BezierClock
{
    public class BezierClock : Form
    {
        BezierClockControl clkctrl;
        bool showUtc;

        public BezierClock(bool useUtc)
        {
            this.showUtc = useUtc;

            BackColor = SystemColors.Window;
            ForeColor = SystemColors.WindowText;

            clkctrl = new BezierClockControl();
            clkctrl.Parent = this;

            if (this.showUtc)
            {
                clkctrl.Time = DateTime.UtcNow;
                Text = "Time Zone:  UTC";
            }
            else
            {
                clkctrl.Time = DateTime.Now;
                Text = $"Time Zone:  Local";
            }

            clkctrl.Dock = DockStyle.Fill;
            clkctrl.BackColor = Color.Black;
            clkctrl.ForeColor = Color.White;

            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Tick += new EventHandler(this.TimerOnTick);
            timer.Start();
        }

        void TimerOnTick(object o, EventArgs e)
        {
            if (this.showUtc)
            {
                clkctrl.Time = DateTime.UtcNow;
            }
            else
            {
                clkctrl.Time = DateTime.Now;
            }
        }
    }
}
