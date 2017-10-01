using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace VisualPathFinder
{
    public class Cube : PictureBox
    {
        public Cube(Point loc, MainForm simulation)
        {
            Location = loc;
            Size = new Size(40, 40);
            BackColor = Color.Gray;
            Click += Click_action;
            simulation.ss += ColorChanged;
        }

        private void Click_action(object sender, EventArgs e)
        {
            BackColor = BuildSettings.builderColor;
        }

        private void ColorChanged(Color col)
        {
            BackColor = Color.Green;
        }
    }
}
