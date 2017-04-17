using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
  using System.Collections.ObjectModel;
  using System.Data;
  using System.Drawing;
  using System.Security.Cryptography.X509Certificates;
  using System.Windows.Forms;

    public class SimulateMouseMovement
  {
    static void Main(string[] args)
    {
        int tick = 1;

        var timer = new System.Timers.Timer();
        timer.Interval = 5000; // tick * MiliSecondsPerMinute;
        timer.Elapsed += MoveCursor;
        timer.Start();
        Console.ReadLine();
    }

       private const int MiliSecondsPerMinute = 60000;
        private static int inverted = 1;

        private static void MoveCursor(object sender, System.Timers.ElapsedEventArgs e)
        {
            // Set the Current cursor, move the cursor's Position,
            // and set its clipping rectangle to the form. 

            Cursor = new Cursor(Cursor.Current.Handle);
            Cursor.Position = new Point(Cursor.Position.X - (inverted * 50), Cursor.Position.Y - (inverted * 50));
            //Cursor.Clip = new Rectangle(this.Location, this.Size);
            inverted *= -1;
        }

        public static Cursor Cursor { get; set; }
  }
}
