using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MyMouseMoving
{
    using System.Configuration;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class Service1 : ServiceBase
    {
        private const int MiliSecondsPerMinute = 60000;
        private static int inverted = 1;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var interval = ConfigurationManager.AppSettings["Interval"];
            int tick = 1;
            if (!int.TryParse(interval, out tick))
            {
                tick = 1;
            }

            var timer = new System.Timers.Timer();
            timer.Interval = tick * MiliSecondsPerMinute;
            timer.Elapsed += this.MoveCursor;
            timer.Start();
        }

        protected override void OnStop()
        {
        }

        private void MoveCursor(object sender, System.Timers.ElapsedEventArgs e)
        {
            // Set the Current cursor, move the cursor's Position,
            // and set its clipping rectangle to the form. 

            this.Cursor = new Cursor(Cursor.Current.Handle);
            Cursor.Position = new Point(Cursor.Position.X - (inverted * 50), Cursor.Position.Y - (inverted * 50));
            //Cursor.Clip = new Rectangle(this.Location, this.Size);
            inverted *= -1;
        }

        public Cursor Cursor { get; set; }
    }
}
