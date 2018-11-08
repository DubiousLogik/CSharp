using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BezierClock
{
    public class AnalogClock : Form
    {
        ClockControl clkctrl;

        public AnalogClock()
        {
            Text = "Analog Clock";
            BackColor = SystemColors.Window;
            ForeColor = SystemColors.WindowText;

            clkctrl = new ClockControl();
            clkctrl.Parent = this;
            clkctrl.Time = DateTime.UtcNow;
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
            clkctrl.Time = DateTime.UtcNow;
        }
    }
}
